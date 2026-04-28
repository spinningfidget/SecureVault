using System.Text.Json;
using SecureVault.Models;

namespace SecureVault.Services;

public class UserService
{
    private static readonly string AppDataRoot = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "SecureVault");

    private static readonly string UsersFile = Path.Combine(AppDataRoot, "users.json");

    private List<User> _users = new();

    public UserService()
    {
        Directory.CreateDirectory(AppDataRoot);
        Load();
    }

    // ─── CRUD ────────────────────────────────────────────────────────────────

    public bool UsernameExists(string username) =>
        _users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

    public bool EmailExists(string email) =>
        _users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

    public (bool success, string error) Register(string username, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            return (false, "Username must be at least 3 characters.");
        if (UsernameExists(username))
            return (false, "Username already taken.");
        if (!IsValidEmail(email))
            return (false, "Invalid e-mail address.");
        if (EmailExists(email))
            return (false, "E-mail already registered.");
        if (password.Length < 10)
            return (false, "Password must be at least 10 characters.");
        if (!HasStrongPassword(password))
            return (false, "Password must contain uppercase, lowercase, digit and special character.");

        var salt = CryptoService.GenerateSalt();
        var hash = CryptoService.HashPassword(password, salt);

        var user = new User
        {
            Username = username.Trim(),
            Email = email.Trim().ToLowerInvariant(),
            Salt = salt,
            PasswordHash = hash,
        };

        // Create personal vault directory
        user.VaultPath = Path.Combine(AppDataRoot, "vaults", user.Id.ToString());
        Directory.CreateDirectory(user.VaultPath);

        _users.Add(user);
        Save();
        return (true, string.Empty);
    }

    public User? Login(string username, string password)
    {
        var user = _users.FirstOrDefault(u =>
            u.Username.Equals(username.Trim(), StringComparison.OrdinalIgnoreCase));

        if (user == null) return null;

        return CryptoService.VerifyPassword(password, user.Salt, user.PasswordHash)
            ? user : null;
    }

    // ─── Persistence ─────────────────────────────────────────────────────────

    private void Load()
    {
        if (!File.Exists(UsersFile)) return;
        try
        {
            var json = File.ReadAllText(UsersFile);
            _users = JsonSerializer.Deserialize<List<User>>(json) ?? new();
        }
        catch { _users = new(); }
    }

    private void Save()
    {
        var json = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(UsersFile, json);
    }

    // ─── Validation helpers ───────────────────────────────────────────────────

    private static bool IsValidEmail(string email)
    {
        try { var _ = new System.Net.Mail.MailAddress(email); return true; }
        catch { return false; }
    }

    private static bool HasStrongPassword(string pwd) =>
        pwd.Any(char.IsUpper) &&
        pwd.Any(char.IsLower) &&
        pwd.Any(char.IsDigit) &&
        pwd.Any(c => !char.IsLetterOrDigit(c));

    public static string GetAppDataRoot() => AppDataRoot;
}
