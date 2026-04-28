namespace SecureVault.Forms
{
    partial class FileEditDialog
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblFileHeader = new Label();
            lblFileValue = new Label();
            btnChoose = new Button();
            lblDescHeader = new Label();
            txtDescription = new TextBox();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(440, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New File";
            // 
            // lblFileHeader
            // 
            lblFileHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFileHeader.ForeColor = Color.FromArgb(160, 175, 200);
            lblFileHeader.Location = new Point(30, 70);
            lblFileHeader.Name = "lblFileHeader";
            lblFileHeader.Size = new Size(80, 20);
            lblFileHeader.TabIndex = 1;
            lblFileHeader.Text = "File";
            // 
            // lblFileValue
            // 
            lblFileValue.Font = new Font("Segoe UI", 9F);
            lblFileValue.ForeColor = Color.FromArgb(110, 125, 160);
            lblFileValue.Location = new Point(30, 92);
            lblFileValue.Name = "lblFileValue";
            lblFileValue.Size = new Size(340, 22);
            lblFileValue.TabIndex = 2;
            lblFileValue.Text = "No file selected";
            // 
            // btnChoose
            // 
            btnChoose.BackColor = Color.FromArgb(30, 34, 54);
            btnChoose.Cursor = Cursors.Hand;
            btnChoose.FlatAppearance.BorderColor = Color.FromArgb(60, 70, 100);
            btnChoose.FlatStyle = FlatStyle.Flat;
            btnChoose.Font = new Font("Segoe UI", 8.5F);
            btnChoose.ForeColor = Color.FromArgb(200, 210, 230);
            btnChoose.Location = new Point(378, 90);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new Size(110, 28);
            btnChoose.TabIndex = 3;
            btnChoose.Text = "Choose File…";
            btnChoose.UseVisualStyleBackColor = false;
            btnChoose.Click += btnChoose_Click;
            // 
            // lblDescHeader
            // 
            lblDescHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescHeader.ForeColor = Color.FromArgb(160, 175, 200);
            lblDescHeader.Location = new Point(30, 130);
            lblDescHeader.Name = "lblDescHeader";
            lblDescHeader.Size = new Size(440, 20);
            lblDescHeader.TabIndex = 4;
            lblDescHeader.Text = "Description (optional)";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(28, 32, 50);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.ForeColor = Color.FromArgb(200, 210, 230);
            txtDescription.Location = new Point(30, 152);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Brief description of this file…";
            txtDescription.Size = new Size(460, 60);
            txtDescription.TabIndex = 5;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 8.5F);
            lblError.ForeColor = Color.FromArgb(245, 101, 101);
            lblError.Location = new Point(30, 220);
            lblError.Name = "lblError";
            lblError.Size = new Size(440, 20);
            lblError.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(99, 179, 237);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.FromArgb(15, 17, 26);
            btnSave.Location = new Point(30, 248);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 40);
            btnSave.TabIndex = 7;
            btnSave.Text = "Encrypt & Add";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(30, 34, 54);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(60, 70, 100);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.FromArgb(160, 175, 200);
            btnCancel.Location = new Point(200, 248);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FileEditDialog
            // 
            BackColor = Color.FromArgb(20, 22, 35);
            ClientSize = new Size(504, 271);
            Controls.Add(lblTitle);
            Controls.Add(lblFileHeader);
            Controls.Add(lblFileValue);
            Controls.Add(btnChoose);
            Controls.Add(lblDescHeader);
            Controls.Add(txtDescription);
            Controls.Add(lblError);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(520, 310);
            MinimumSize = new Size(520, 310);
            Name = "FileEditDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add File to Vault";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ─── Designer control declarations ───────────────────────────────────────

        private Label lblTitle;
        private Label lblFileHeader;
        private Label lblFileValue;
        private Button btnChoose;
        private Label lblDescHeader;
        private TextBox txtDescription;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;
    }
}
