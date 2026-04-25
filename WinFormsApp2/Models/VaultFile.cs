namespace WinFormsApp2.Models;

public class VaultFile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OriginalName { get; set; } = string.Empty;
    public string EncryptedFileName { get; set; } = string.Empty; // stored name on disk
    public string Description { get; set; } = string.Empty;
    public long SizeBytes { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public string MimeType { get; set; } = string.Empty;

    public string DisplaySize =>
        SizeBytes < 1024 ? $"{SizeBytes} B" :
        SizeBytes < 1048576 ? $"{SizeBytes / 1024.0:F1} KB" :
        $"{SizeBytes / 1048576.0:F1} MB";
}
