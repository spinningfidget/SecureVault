using System.Text.Json;
using WinFormsApp2.Models;

namespace WinFormsApp2.Services
{
    /// <summary>
    /// Manages the encrypted file vault for a single logged-in user.
    /// Files are stored encrypted on disk; metadata manifest is also AES-256-GCM encrypted.
    /// </summary>
    public class VaultService
    {
        private readonly User _user;
        private readonly string _password;   // kept in memory only for session lifetime
        private readonly string _manifestPath;
        private List<VaultFile> _files = new();

        public IReadOnlyList<VaultFile> Files => _files.AsReadOnly();

        public VaultService(User user, string password)
        {
            _user = user;
            _password = password;
            _manifestPath = Path.Combine(user.VaultPath, ".manifest");
            LoadManifest();
        }

        // ─── Manifest ────────────────────────────────────────────────────────────

        private void LoadManifest()
        {
            if (!File.Exists(_manifestPath)) return;
            try
            {
                var blob = File.ReadAllText(_manifestPath);
                var json = CryptoService.DecryptManifest(blob, _password, _user.Salt);
                _files = JsonSerializer.Deserialize<List<VaultFile>>(json) ?? new();
            }
            catch { _files = new(); }
        }

        private void SaveManifest()
        {
            var json = JsonSerializer.Serialize(_files);
            var blob = CryptoService.EncryptManifest(json, _password, _user.Salt);
            File.WriteAllText(_manifestPath, blob);
        }

        // ─── Operations ──────────────────────────────────────────────────────────

        /// <summary>Adds and encrypts a file into the user's vault.</summary>
        public VaultFile AddFile(string sourcePath, string description = "")
        {
            var info = new FileInfo(sourcePath);
            var vaultFile = new VaultFile
            {
                OriginalName = info.Name,
                EncryptedFileName = Guid.NewGuid().ToString("N") + ".enc",
                Description = description,
                SizeBytes = info.Length,
                MimeType = GetMimeType(info.Extension),
            };

            var destPath = Path.Combine(_user.VaultPath, vaultFile.EncryptedFileName);
            CryptoService.EncryptFile(sourcePath, destPath, _password);

            _files.Add(vaultFile);
            SaveManifest();
            return vaultFile;
        }

        /// <summary>Decrypts a vault file to a temp path and returns it for opening.</summary>
        public string ExportFile(VaultFile vaultFile, string? destDirectory = null)
        {
            destDirectory ??= Path.GetTempPath();
            var destPath = Path.Combine(destDirectory, vaultFile.OriginalName);
            var srcPath = Path.Combine(_user.VaultPath, vaultFile.EncryptedFileName);
            CryptoService.DecryptFile(srcPath, destPath, _password);
            return destPath;
        }

        /// <summary>Updates metadata of an existing file (re-encrypts if replacing content).</summary>
        public void UpdateFile(VaultFile vaultFile, string? newSourcePath, string description)
        {
            var existing = _files.FirstOrDefault(f => f.Id == vaultFile.Id)
                ?? throw new FileNotFoundException("File not found in vault.");

            existing.Description = description;
            existing.ModifiedAt = DateTime.UtcNow;

            if (newSourcePath != null)
            {
                var info = new FileInfo(newSourcePath);
                existing.OriginalName = info.Name;
                existing.SizeBytes = info.Length;
                existing.MimeType = GetMimeType(info.Extension);

                var encPath = Path.Combine(_user.VaultPath, existing.EncryptedFileName);
                if (File.Exists(encPath)) File.Delete(encPath);
                CryptoService.EncryptFile(newSourcePath, encPath, _password);
            }

            SaveManifest();
        }

        /// <summary>Permanently deletes a file from the vault.</summary>
        public void DeleteFile(VaultFile vaultFile)
        {
            var existing = _files.FirstOrDefault(f => f.Id == vaultFile.Id);
            if (existing == null) return;

            var encPath = Path.Combine(_user.VaultPath, existing.EncryptedFileName);
            if (File.Exists(encPath))
            {
                // Secure delete: overwrite with random bytes before deleting
                SecureDelete(encPath);
            }

            _files.Remove(existing);
            SaveManifest();
        }

        // ─── Helpers ─────────────────────────────────────────────────────────────

        private static void SecureDelete(string path)
        {
            try
            {
                var info = new FileInfo(path);
                var len = info.Length;
                using (var fs = info.OpenWrite())
                {
                    var random = System.Security.Cryptography.RandomNumberGenerator.GetBytes((int)Math.Min(len, 65536));
                    long written = 0;
                    while (written < len)
                    {
                        int toWrite = (int)Math.Min(random.Length, len - written);
                        fs.Write(random, 0, toWrite);
                        written += toWrite;
                    }
                }
                File.Delete(path);
            }
            catch { File.Delete(path); }
        }

        private static string GetMimeType(string ext) => ext.ToLowerInvariant() switch
        {
            ".pdf" => "application/pdf",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".txt" => "text/plain",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".zip" => "application/zip",
            ".mp4" => "video/mp4",
            _ => "application/octet-stream"
        };
    }
}