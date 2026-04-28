namespace SecureVault.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;   // PBKDF2-SHA512
    public string Salt { get; set; } = string.Empty;           // Base64 random salt
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string VaultPath { get; set; } = string.Empty;      // Per-user encrypted folder
}
