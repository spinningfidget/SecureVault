using SecureVault.Models;

namespace SecureVault.Forms
{
    public partial class FileEditDialog : Form
    {
        public string? SelectedFilePath { get; private set; }
        public string Description { get; private set; } = string.Empty;

        private readonly VaultFile? _existing;

        public FileEditDialog(VaultFile? existing = null)
        {
            _existing = existing;
            InitializeComponent();

            // Populate runtime-dependent text
            bool isEdit = _existing != null;
            this.Text = isEdit ? "Edit File" : "Add File to Vault";
            lblTitle.Text = isEdit ? "Edit File Details" : "Add New File";
            btnChoose.Text = isEdit ? "Replace File…" : "Choose File…";
            btnSave.Text = isEdit ? "Save Changes" : "Encrypt & Add";
            lblFileValue.Text = isEdit
                ? $"Current: {_existing!.OriginalName}  (leave blank to keep)"
                : "No file selected";
            txtDescription.Text = _existing?.Description ?? string.Empty;
        }

        // ─── Events ──────────────────────────────────────────────────────────────

        private void btnChoose_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Select a file to encrypt",
                Filter = "All files (*.*)|*.*",
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SelectedFilePath = dlg.FileName;
                lblFileValue.Text = Path.GetFileName(dlg.FileName);
                lblFileValue.ForeColor = Color.FromArgb(72, 199, 142);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            if (_existing == null && string.IsNullOrEmpty(SelectedFilePath))
            {
                lblError.Text = "⚠  Please choose a file to add.";
                return;
            }

            Description = txtDescription.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}