using SecureVault.Models;
using SecureVault.Services;

namespace SecureVault.Forms;

public partial class DashboardForm : Form
{
    private readonly User _user;
    private readonly VaultService _vault;

    public DashboardForm(User user, VaultService vault)
    {
        _user = user;
        _vault = vault;
        InitializeComponent();

        // Set runtime-only text that depends on user data
        this.Text = $"SecureVault — {_user.Username}'s Dashboard";
        lblWelcome.Text = $"Welcome, {_user.Username}";
        lblEmail.Text = $"  {_user.Email}";

        // Wire resize-based layout for logout button
        pnlTopBar.Resize += (_, _) =>
            btnLogout.Location = new Point(pnlTopBar.Width - 150, 20);

        RefreshList();
    }

    // ─── Data refresh ────────────────────────────────────────────────────────

    private void RefreshList()
    {
        listFiles.Items.Clear();

        foreach (var f in _vault.Files)
        {
            var item = new ListViewItem($"  {f.OriginalName}");
            item.SubItems.Add(f.Description);
            item.SubItems.Add(f.MimeType.Split('/').Last().ToUpperInvariant());
            item.SubItems.Add(f.DisplaySize);
            item.SubItems.Add(f.UploadedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm"));
            item.SubItems.Add(f.ModifiedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm"));
            item.Tag = f;
            item.ForeColor = Color.FromArgb(200, 210, 230);
            listFiles.Items.Add(item);
        }

        RefreshStats();
        SetStatus($"{_vault.Files.Count} file(s) in vault  |  AES-256-CBC encrypted");
    }

    private void RefreshStats()
    {
        pnlStats.Controls.Clear();

        long totalBytes = _vault.Files.Sum(f => f.SizeBytes);

        var stats = new[]
        {
            ("📁", _vault.Files.Count.ToString(), "Total Files"),
            ("💾", FormatBytes(totalBytes),        "Vault Size"),
            ("🔒", "AES-256-CBC",                 "Encryption"),
            ("🛡️", "PBKDF2-SHA512",               "Key Derivation"),
        };

        int x = 0;
        foreach (var (icon, val, lbl) in stats)
        {
            var card = new Panel
            {
                Location = new Point(x, 8),
                Size = new Size(200, 64),
                BackColor = Color.FromArgb(24, 28, 46),
            };

            card.Controls.Add(new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 18),
                Location = new Point(10, 10),
                Size = new Size(40, 44),
            });
            card.Controls.Add(new Label
            {
                Text = val,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(99, 179, 237),
                Location = new Point(56, 8),
                Size = new Size(140, 26),
            });
            card.Controls.Add(new Label
            {
                Text = lbl,
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(100, 115, 145),
                Location = new Point(58, 34),
                Size = new Size(140, 18),
            });

            pnlStats.Controls.Add(card);
            x += 214;
        }
    }

    private void UpdateButtonStates()
    {
        bool sel = listFiles.SelectedItems.Count > 0;
        btnEdit.Enabled = sel;
        btnDelete.Enabled = sel;
        btnOpen.Enabled = sel;
    }

    private VaultFile? SelectedFile =>
        listFiles.SelectedItems.Count > 0
            ? listFiles.SelectedItems[0].Tag as VaultFile
            : null;

    // ─── Events ──────────────────────────────────────────────────────────────

    private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        => UpdateButtonStates();

    private void listFiles_DoubleClick(object sender, EventArgs e)
        => btnOpen_Click(sender, e);

    private void btnLogout_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Retry;
        Close();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using var dlg = new FileEditDialog();
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        SetStatus("Encrypting file…");
        Cursor = Cursors.WaitCursor;
        try
        {
            _vault.AddFile(dlg.SelectedFilePath!, dlg.Description);
            RefreshList();
            SetStatus("File encrypted and added to vault.");
        }
        catch (Exception ex)
        {
            ShowError("Encryption failed", ex.Message);
            SetStatus("Error during encryption.");
        }
        finally { Cursor = Cursors.Default; }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        var file = SelectedFile;
        if (file == null) return;

        using var dlg = new FileEditDialog(file);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        SetStatus("Updating vault entry…");
        Cursor = Cursors.WaitCursor;
        try
        {
            _vault.UpdateFile(file, dlg.SelectedFilePath, dlg.Description);
            RefreshList();
            SetStatus("File updated.");
        }
        catch (Exception ex) { ShowError("Update failed", ex.Message); }
        finally { Cursor = Cursors.Default; }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var file = SelectedFile;
        if (file == null) return;

        var confirm = MessageBox.Show(
            $"Permanently delete '{file.OriginalName}' from the vault?\n\nThe encrypted file will be securely wiped.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirm != DialogResult.Yes) return;

        Cursor = Cursors.WaitCursor;
        try
        {
            _vault.DeleteFile(file);
            RefreshList();
            SetStatus("File securely deleted.");
        }
        catch (Exception ex) { ShowError("Delete failed", ex.Message); }
        finally { Cursor = Cursors.Default; }
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
        var file = SelectedFile;
        if (file == null) return;

        using var fbd = new FolderBrowserDialog
        {
            Description = $"Choose where to export '{file.OriginalName}'",
            UseDescriptionForTitle = true,
        };

        if (fbd.ShowDialog(this) != DialogResult.OK) return;

        SetStatus("Decrypting and exporting…");
        Cursor = Cursors.WaitCursor;
        try
        {
            var path = _vault.ExportFile(file, fbd.SelectedPath);
            SetStatus($"Exported to: {path}");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true,
            });
        }
        catch (System.Security.Cryptography.CryptographicException cex)
        {
            ShowError("Authentication Error", $"File integrity check failed:\n{cex.Message}");
        }
        catch (Exception ex) { ShowError("Export failed", ex.Message); }
        finally { Cursor = Cursors.Default; }
    }

    // ─── Helpers ─────────────────────────────────────────────────────────────

    private void SetStatus(string msg) =>
        lblStatus.Text = $"  {msg}  |  {DateTime.Now:HH:mm:ss}";

    private static void ShowError(string title, string msg) =>
        MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

    private static string FormatBytes(long b) =>
        b < 1024 ? $"{b} B" :
        b < 1048576 ? $"{b / 1024.0:F1} KB" :
                        $"{b / 1048576.0:F1} MB";
}
