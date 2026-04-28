namespace SecureVault.Forms
{
    public partial class DashboardForm
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
            this.components = new System.ComponentModel.Container();

            this.pnlTopBar = new Panel();
            this.lblLogo = new Label();
            this.lblWelcome = new Label();
            this.lblEmail = new Label();
            this.btnLogout = new Button();
            this.pnlStats = new Panel();
            this.pnlToolbar = new Panel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnOpen = new Button();
            this.pnlListOuter = new Panel();
            this.listFiles = new ListView();
            this.colName = new ColumnHeader();
            this.colDesc = new ColumnHeader();
            this.colType = new ColumnHeader();
            this.colSize = new ColumnHeader();
            this.colAdded = new ColumnHeader();
            this.colModified = new ColumnHeader();
            this.pnlStatusBar = new Panel();
            this.lblStatus = new Label();

            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════════════
            // Form
            // ════════════════════════════════════════════════════════════════════
            this.Text = "SecureVault — Dashboard";
            this.ClientSize = new Size(1100, 720);
            this.MinimumSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(15, 17, 26);

            // ════════════════════════════════════════════════════════════════════
            // Status bar (bottom — add first so Fill works correctly)
            // ════════════════════════════════════════════════════════════════════
            this.pnlStatusBar.Dock = DockStyle.Bottom;
            this.pnlStatusBar.Height = 28;
            this.pnlStatusBar.BackColor = Color.FromArgb(12, 14, 22);

            this.lblStatus.Text = "  Ready  |  All files encrypted with AES-256-CBC + HMAC-SHA256";
            this.lblStatus.Font = new Font("Segoe UI", 8);
            this.lblStatus.ForeColor = Color.FromArgb(80, 95, 130);
            this.lblStatus.Dock = DockStyle.Fill;
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            this.pnlStatusBar.Controls.Add(this.lblStatus);

            // ════════════════════════════════════════════════════════════════════
            // Top bar
            // ════════════════════════════════════════════════════════════════════
            this.pnlTopBar.Dock = DockStyle.Top;
            this.pnlTopBar.Height = 76;
            this.pnlTopBar.BackColor = Color.FromArgb(20, 22, 35);
            this.pnlTopBar.Padding = new Padding(20, 0, 20, 0);

            this.lblLogo.Text = "🔐 SecureVault";
            this.lblLogo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblLogo.ForeColor = Color.FromArgb(99, 179, 237);
            this.lblLogo.Location = new Point(20, 20);
            this.lblLogo.Size = new Size(260, 36);

            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(300, 16);
            this.lblWelcome.Size = new Size(400, 28);

            this.lblEmail.Text = "";
            this.lblEmail.Font = new Font("Segoe UI", 9);
            this.lblEmail.ForeColor = Color.FromArgb(110, 125, 160);
            this.lblEmail.Location = new Point(298, 44);
            this.lblEmail.Size = new Size(400, 20);

            this.btnLogout.Text = "⬡  Sign Out";
            this.btnLogout.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnLogout.Size = new Size(120, 36);
            this.btnLogout.Location = new Point(930, 20);
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.BackColor = Color.FromArgb(30, 34, 54);
            this.btnLogout.ForeColor = Color.FromArgb(200, 210, 230);
            this.btnLogout.Font = new Font("Segoe UI", 9);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderColor = Color.FromArgb(60, 70, 100);
            this.btnLogout.Click += this.btnLogout_Click;

            this.pnlTopBar.Controls.AddRange(new Control[]
            {
            this.lblLogo, this.lblWelcome, this.lblEmail, this.btnLogout
            });

            // ════════════════════════════════════════════════════════════════════
            // Stats panel
            // ════════════════════════════════════════════════════════════════════
            this.pnlStats.Dock = DockStyle.Top;
            this.pnlStats.Height = 88;
            this.pnlStats.BackColor = Color.FromArgb(18, 20, 32);
            this.pnlStats.Padding = new Padding(20, 12, 20, 12);
            // Cards are populated at runtime in RefreshStats()

            // ════════════════════════════════════════════════════════════════════
            // Toolbar
            // ════════════════════════════════════════════════════════════════════
            this.pnlToolbar.Dock = DockStyle.Top;
            this.pnlToolbar.Height = 56;
            this.pnlToolbar.BackColor = Color.FromArgb(20, 22, 35);

            ConfigureToolbarButton(this.btnAdd, "＋  Add File", Color.FromArgb(72, 199, 142), Color.FromArgb(15, 17, 26), 16);
            ConfigureToolbarButton(this.btnEdit, "✎  Edit", Color.FromArgb(99, 179, 237), Color.FromArgb(15, 17, 26), 174);
            ConfigureToolbarButton(this.btnDelete, "🗑  Delete", Color.FromArgb(245, 101, 101), Color.White, 332);
            ConfigureToolbarButton(this.btnOpen, "⬇  Export & Open", Color.FromArgb(160, 120, 220), Color.White, 490);

            this.btnAdd.Click += this.btnAdd_Click;
            this.btnEdit.Click += this.btnEdit_Click;
            this.btnDelete.Click += this.btnDelete_Click;
            this.btnOpen.Click += this.btnOpen_Click;

            this.pnlToolbar.Controls.AddRange(new Control[]
            {
            this.btnAdd, this.btnEdit, this.btnDelete, this.btnOpen
            });

            // ════════════════════════════════════════════════════════════════════
            // File list
            // ════════════════════════════════════════════════════════════════════
            this.pnlListOuter.Dock = DockStyle.Fill;
            this.pnlListOuter.Padding = new Padding(16, 12, 16, 12);
            this.pnlListOuter.BackColor = Color.FromArgb(15, 17, 26);

            this.listFiles.Dock = DockStyle.Fill;
            this.listFiles.View = View.Details;
            this.listFiles.FullRowSelect = true;
            this.listFiles.GridLines = false;
            this.listFiles.BackColor = Color.FromArgb(20, 22, 35);
            this.listFiles.ForeColor = Color.FromArgb(200, 210, 230);
            this.listFiles.Font = new Font("Segoe UI", 9.5f);
            this.listFiles.BorderStyle = BorderStyle.None;
            this.listFiles.MultiSelect = false;
            this.listFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            this.colName.Text = "  File Name";
            this.colName.Width = 240;
            this.colDesc.Text = "Description";
            this.colDesc.Width = 280;
            this.colType.Text = "Type";
            this.colType.Width = 90;
            this.colSize.Text = "Size";
            this.colSize.Width = 80;
            this.colAdded.Text = "Added";
            this.colAdded.Width = 130;
            this.colModified.Text = "Modified";
            this.colModified.Width = 130;

            this.listFiles.Columns.AddRange(new ColumnHeader[]
            {
            this.colName, this.colDesc, this.colType,
            this.colSize, this.colAdded, this.colModified
            });

            this.listFiles.SelectedIndexChanged += this.listFiles_SelectedIndexChanged;
            this.listFiles.DoubleClick += this.listFiles_DoubleClick;

            this.pnlListOuter.Controls.Add(this.listFiles);

            // ════════════════════════════════════════════════════════════════════
            // Assemble form (order matters for Dock stacking)
            // ════════════════════════════════════════════════════════════════════
            this.Controls.AddRange(new Control[]
            {
            this.pnlListOuter,   // Fill — must be added before Top panels
            this.pnlStatusBar,
            this.pnlToolbar,
            this.pnlStats,
            this.pnlTopBar,
            });

            this.ResumeLayout(false);
        }

        private static void ConfigureToolbarButton(Button btn, string text, Color bg, Color fg, int x)
        {
            btn.Text = text;
            btn.Location = new Point(x, 10);
            btn.Size = new Size(148, 36);
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = bg;
            btn.ForeColor = fg;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.BorderSize = 0;
        }

        #endregion

        // ─── Designer control declarations ───────────────────────────────────────

        private Panel pnlTopBar;
        private Label lblLogo;
        private Label lblWelcome;
        private Label lblEmail;
        private Button btnLogout;
        private Panel pnlStats;
        private Panel pnlToolbar;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnOpen;
        private Panel pnlListOuter;
        private ListView listFiles;
        private ColumnHeader colName;
        private ColumnHeader colDesc;
        private ColumnHeader colType;
        private ColumnHeader colSize;
        private ColumnHeader colAdded;
        private ColumnHeader colModified;
        private Panel pnlStatusBar;
        private Label lblStatus;
    }
}
