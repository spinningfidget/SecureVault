using System.Security.Cryptography;
using System.Text;

namespace SecureVault.Services;

/// <summary>
/// Cryptographic service implementing EU-standard encryption:
/// - Password hashing: PBKDF2-HMAC-SHA512, 310 000 iterations, 32-byte salt (OWASP 2024 / NIST SP 800-132)
/// - File encryption: AES-256-CBC with HMAC-SHA256 for authenticated encryption (Encrypt-then-MAC)
///   (AES-256-GCM via .NET 8 AesGcm for smaller data, CBC+HMAC fallback for streaming)
/// - Key derivation from user password: PBKDF2 → per-file random IV
/// Complies with: GDPR Art. 32, BSI TR-02102-1, ENISA guidelines, ISO/IEC 27001
/// </summary>
public static class CryptoService
{
    private const int SaltSize = 32;           // 256-bit salt
    private const int HashSize = 64;           // 512-bit output (SHA-512)
    private const int Pbkdf2Iterations = 310_000; // OWASP 2024 recommendation for PBKDF2-SHA512
    private const int AesKeySize = 32;         // 256-bit AES key
    private const int IvSize = 16;             // 128-bit IV for AES-CBC
    private const int HmacKeySize = 32;        // 256-bit HMAC key
    private const int GcmNonceSize = 12;       // 96-bit nonce for AES-GCM
    private const int GcmTagSize = 16;         // 128-bit authentication tag

    // ─── Password Hashing ───────────────────────────────────────────────────

    /// <summary>Returns a new random Base64 salt.</summary>
    public static string GenerateSalt()
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        return Convert.ToBase64String(salt);
    }

    /// <summary>
    /// Derives a PBKDF2-HMAC-SHA512 hash from the password.
    /// Storage format: Base64(hash)
    /// </summary>
    public static string HashPassword(string password, string saltBase64)
    {
        var salt = Convert.FromBase64String(saltBase64);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            Pbkdf2Iterations,
            HashAlgorithmName.SHA512,
            HashSize);
        return Convert.ToBase64String(hash);
    }

    /// <summary>Constant-time comparison to prevent timing attacks.</summary>
    public static bool VerifyPassword(string password, string saltBase64, string storedHashBase64)
    {
        var computed = HashPassword(password, saltBase64);
        return CryptographicOperations.FixedTimeEquals(
            Convert.FromBase64String(computed),
            Convert.FromBase64String(storedHashBase64));
    }

    // ─── Key Derivation ─────────────────────────────────────────────────────

    /// <summary>
    /// Derives AES-256 + HMAC-256 keys from user password for file encryption.
    /// Uses a separate derivation salt stored alongside the file.
    /// </summary>
    private static (byte[] aesKey, byte[] hmacKey) DeriveFileKeys(string password, byte[] derivationSalt)
    {
        // Derive 64 bytes: first 32 = AES key, second 32 = HMAC key
        var keyMaterial = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            derivationSalt,
            Pbkdf2Iterations,
            HashAlgorithmName.SHA512,
            AesKeySize + HmacKeySize);

        var aesKey = keyMaterial[..AesKeySize];
        var hmacKey = keyMaterial[AesKeySize..];
        return (aesKey, hmacKey);
    }

    // ─── File Encryption (AES-256-CBC + HMAC-SHA256, Encrypt-then-MAC) ──────

    /// <summary>
    /// Encrypts a file using AES-256-CBC with Encrypt-then-MAC (HMAC-SHA256).
    /// Output format: [derivationSalt(32)] [IV(16)] [ciphertext] [HMAC(32)]
    /// </summary>
    public static void EncryptFile(string sourcePath, string destPath, string userPassword)
    {
        var derivationSalt = RandomNumberGenerator.GetBytes(SaltSize);
        var (aesKey, hmacKey) = DeriveFileKeys(userPassword, derivationSalt);
        var iv = RandomNumberGenerator.GetBytes(IvSize);

        using var sourceStream = File.OpenRead(sourcePath);
        using var destStream = File.OpenWrite(destPath);

        // Write header: derivationSalt + IV (will be MAC'd)
        destStream.Write(derivationSalt);
        destStream.Write(iv);

        // Encrypt
        using var aes = Aes.Create();
        aes.Key = aesKey;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        // Buffer entire ciphertext so we can HMAC it (Encrypt-then-MAC)
        using var memStream = new MemoryStream();
        using (var encryptor = aes.CreateEncryptor())
        using (var cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
        {
            sourceStream.CopyTo(cryptoStream);
        }

        var ciphertext = memStream.ToArray();
        destStream.Write(ciphertext);

        // Compute HMAC over: derivationSalt || IV || ciphertext
        using var hmac = new HMACSHA256(hmacKey);
        hmac.TransformBlock(derivationSalt, 0, derivationSalt.Length, null, 0);
        hmac.TransformBlock(iv, 0, iv.Length, null, 0);
        hmac.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
        destStream.Write(hmac.Hash!);
    }

    /// <summary>
    /// Decrypts a file encrypted with EncryptFile.
    /// Verifies HMAC before decryption (authenticate-then-decrypt).
    /// </summary>
    public static void DecryptFile(string sourcePath, string destPath, string userPassword)
    {
        using var sourceStream = File.OpenRead(sourcePath);
        using var reader = new BinaryReader(sourceStream);

        var derivationSalt = reader.ReadBytes(SaltSize);
        var iv = reader.ReadBytes(IvSize);

        var remaining = (int)(sourceStream.Length - SaltSize - IvSize);
        if (remaining <= 32) throw new CryptographicException("File too short – corrupted?");

        var ciphertext = reader.ReadBytes(remaining - 32);
        var storedMac = reader.ReadBytes(32);

        var (aesKey, hmacKey) = DeriveFileKeys(userPassword, derivationSalt);

        // Verify HMAC first (prevents padding oracle attacks)
        using var hmac = new HMACSHA256(hmacKey);
        hmac.TransformBlock(derivationSalt, 0, derivationSalt.Length, null, 0);
        hmac.TransformBlock(iv, 0, iv.Length, null, 0);
        hmac.TransformFinalBlock(ciphertext, 0, ciphertext.Length);

        if (!CryptographicOperations.FixedTimeEquals(hmac.Hash!, storedMac))
            throw new CryptographicException("Authentication failed: file may be tampered with.");

        // Decrypt
        using var aes = Aes.Create();
        aes.Key = aesKey;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var destStream = File.OpenWrite(destPath);
        using var memStream = new MemoryStream(ciphertext);
        using var decryptor = aes.CreateDecryptor();
        using var cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read);
        cryptoStream.CopyTo(destStream);
    }

    // ─── Manifest Encryption (user's file index) ────────────────────────────

    /// <summary>
    /// Encrypts arbitrary text (JSON manifest) using AES-256-GCM.
    /// Output: Base64( nonce(12) || tag(16) || ciphertext )
    /// </summary>
    public static string EncryptManifest(string plaintext, string userPassword, string saltBase64)
    {
        var salt = Convert.FromBase64String(saltBase64);
        var key = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(userPassword),  // Remove 'password:' 
            salt,
            Pbkdf2Iterations,
            HashAlgorithmName.SHA512,
            AesKeySize);
        var nonce = RandomNumberGenerator.GetBytes(GcmNonceSize);
        var plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
        var ciphertext = new byte[plaintextBytes.Length];
        var tag = new byte[GcmTagSize];

        using var gcm = new AesGcm(key, GcmTagSize);
        gcm.Encrypt(nonce, plaintextBytes, ciphertext, tag);

        var result = new byte[GcmNonceSize + GcmTagSize + ciphertext.Length];
        nonce.CopyTo(result, 0);
        tag.CopyTo(result, GcmNonceSize);
        ciphertext.CopyTo(result, GcmNonceSize + GcmTagSize);

        return Convert.ToBase64String(result);
    }

    public static string DecryptManifest(string base64Blob, string userPassword, string saltBase64)
    {
        var blob = Convert.FromBase64String(base64Blob);
        if (blob.Length < GcmNonceSize + GcmTagSize)
            throw new CryptographicException("Invalid manifest blob.");

        var nonce = blob[..GcmNonceSize];
        var tag = blob[GcmNonceSize..(GcmNonceSize + GcmTagSize)];
        var ciphertext = blob[(GcmNonceSize + GcmTagSize)..];

        var salt = Convert.FromBase64String(saltBase64);
        var key = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(userPassword),
            salt, Pbkdf2Iterations, HashAlgorithmName.SHA512, AesKeySize);

        var plaintext = new byte[ciphertext.Length];
        using var gcm = new AesGcm(key, GcmTagSize);
        gcm.Decrypt(nonce, ciphertext, tag, plaintext);

        return Encoding.UTF8.GetString(plaintext);
    }
}
