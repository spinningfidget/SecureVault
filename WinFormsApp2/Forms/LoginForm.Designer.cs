namespace SecureVault.Forms
{
    partial class LoginForm
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
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

            // ── Controls declared in designer order ───────────────────────────────
            this.pnlSide = new Panel();
            this.pnlLogo = new Panel();
            this.lblLogo = new Label();
            this.lblAppTitle = new Label();
            this.pnlBullets = new Panel();
            this.pnlBullet1 = new Panel();
            this.lblBullet1Icon = new Label();
            this.lblBullet1Head = new Label();
            this.lblBullet1Sub = new Label();
            this.pnlBullet2 = new Panel();
            this.lblBullet2Icon = new Label();
            this.lblBullet2Head = new Label();
            this.lblBullet2Sub = new Label();
            this.pnlBullet3 = new Panel();
            this.lblBullet3Icon = new Label();
            this.lblBullet3Head = new Label();
            this.lblBullet3Sub = new Label();
            this.pnlBullet4 = new Panel();
            this.lblBullet4Icon = new Label();
            this.lblBullet4Head = new Label();
            this.lblBullet4Sub = new Label();
            this.pnlMain = new Panel();
            this.tabControl = new TabControl();
            this.tabLogin = new TabPage();
            this.pnlLoginInner = new Panel();
            this.lblLoginTitle = new Label();
            this.lblLoginSub = new Label();
            this.lblLoginUsername = new Label();
            this.txtLoginUsername = new TextBox();
            this.lblLoginPassword = new Label();
            this.txtLoginPassword = new TextBox();
            this.lblLoginError = new Label();
            this.btnLogin = new Button();
            this.lblLoginHint = new Label();
            this.tabRegister = new TabPage();
            this.pnlRegInner = new Panel();
            this.lblRegTitle = new Label();
            this.lblRegSub = new Label();
            this.lblRegUsername = new Label();
            this.txtRegUsername = new TextBox();
            this.lblRegEmail = new Label();
            this.txtRegEmail = new TextBox();
            this.lblRegPassword = new Label();
            this.txtRegPassword = new TextBox();
            this.lblRegConfirm = new Label();
            this.txtRegConfirm = new TextBox();
            this.lblRegError = new Label();
            this.lblRegSuccess = new Label();
            this.btnRegister = new Button();

            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════════════
            // Form
            // ════════════════════════════════════════════════════════════════════
            this.Text = "SecureVault — Secure File Storage";
            this.ClientSize = new Size(900, 620);
            this.MinimumSize = new Size(900, 620);
            this.MaximumSize = new Size(900, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(15, 17, 26);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // ════════════════════════════════════════════════════════════════════
            // Side panel
            // ════════════════════════════════════════════════════════════════════
            this.pnlSide.Dock = DockStyle.Left;
            this.pnlSide.Width = 320;
            this.pnlSide.BackColor = Color.FromArgb(20, 22, 35);

            // Logo sub-panel
            this.pnlLogo.Dock = DockStyle.Top;
            this.pnlLogo.Height = 180;
            this.pnlLogo.BackColor = Color.FromArgb(30, 34, 54);

            this.lblLogo.Text = "🔐";
            this.lblLogo.Font = new Font("Segoe UI Emoji", 42);
            this.lblLogo.ForeColor = Color.White;
            this.lblLogo.AutoSize = false;
            this.lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLogo.Dock = DockStyle.Top;
            this.lblLogo.Height = 100;

            this.lblAppTitle.Text = "SecureVault";
            this.lblAppTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            this.lblAppTitle.ForeColor = Color.FromArgb(99, 179, 237);
            this.lblAppTitle.AutoSize = false;
            this.lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblAppTitle.Dock = DockStyle.Fill;

            this.pnlLogo.Controls.Add(this.lblAppTitle);
            this.pnlLogo.Controls.Add(this.lblLogo);

            // Bullets panel
            this.pnlBullets.Dock = DockStyle.Fill;
            this.pnlBullets.Padding = new Padding(24, 20, 24, 0);

            BuildBulletRow(this.pnlBullet1, this.lblBullet1Icon, this.lblBullet1Head, this.lblBullet1Sub,
                0, "🔒", "AES-256 Encryption", "EU GDPR & NIS2 Compliant");
            BuildBulletRow(this.pnlBullet2, this.lblBullet2Icon, this.lblBullet2Head, this.lblBullet2Sub,
                64, "🛡️", "PBKDF2-SHA512 Hashing", "310,000 Iterations");
            BuildBulletRow(this.pnlBullet3, this.lblBullet3Icon, this.lblBullet3Head, this.lblBullet3Sub,
                128, "📁", "Per-User Secure Vault", "Isolated Encrypted Storage");
            BuildBulletRow(this.pnlBullet4, this.lblBullet4Icon, this.lblBullet4Head, this.lblBullet4Sub,
                192, "✅", "Authenticate-then-Decrypt", "Tamper Detection Built-in");

            this.pnlBullets.Controls.AddRange(new Control[]
            {
            this.pnlBullet1, this.pnlBullet2, this.pnlBullet3, this.pnlBullet4
            });

            this.pnlSide.Controls.Add(this.pnlBullets);
            this.pnlSide.Controls.Add(this.pnlLogo);

            // ════════════════════════════════════════════════════════════════════
            // Main panel + TabControl
            // ════════════════════════════════════════════════════════════════════
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.BackColor = Color.FromArgb(15, 17, 26);
            this.pnlMain.Padding = new Padding(40, 40, 40, 40);

            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("Segoe UI", 10);
            this.tabControl.Appearance = TabAppearance.FlatButtons;
            this.tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl.ItemSize = new Size(130, 36);
            this.tabControl.DrawItem += this.tabControl_DrawItem;

            // ── Login Tab ────────────────────────────────────────────────────────
            this.tabLogin.Text = "  Sign In  ";
            this.tabLogin.BackColor = Color.FromArgb(15, 17, 26);

            this.pnlLoginInner.Dock = DockStyle.Fill;
            this.pnlLoginInner.Padding = new Padding(30, 20, 30, 20);

            this.lblLoginTitle.Text = "Welcome back";
            this.lblLoginTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblLoginTitle.ForeColor = Color.White;
            this.lblLoginTitle.Location = new Point(0, 0);
            this.lblLoginTitle.Size = new Size(500, 34);

            this.lblLoginSub.Text = "Sign in to access your encrypted vault";
            this.lblLoginSub.Font = new Font("Segoe UI", 9);
            this.lblLoginSub.ForeColor = Color.FromArgb(110, 125, 160);
            this.lblLoginSub.Location = new Point(0, 38);
            this.lblLoginSub.Size = new Size(500, 20);

            this.lblLoginUsername.Text = "Username";
            this.lblLoginUsername.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblLoginUsername.ForeColor = Color.FromArgb(160, 175, 200);
            this.lblLoginUsername.Location = new Point(0, 90);
            this.lblLoginUsername.Size = new Size(200, 20);

            this.txtLoginUsername.Location = new Point(0, 112);
            this.txtLoginUsername.Size = new Size(380, 28);
            this.txtLoginUsername.Font = new Font("Segoe UI", 11);
            this.txtLoginUsername.BackColor = Color.FromArgb(28, 32, 50);
            this.txtLoginUsername.ForeColor = Color.FromArgb(200, 210, 230);
            this.txtLoginUsername.BorderStyle = BorderStyle.FixedSingle;
            this.txtLoginUsername.PlaceholderText = "Enter your username";

            this.lblLoginPassword.Text = "Password";
            this.lblLoginPassword.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblLoginPassword.ForeColor = Color.FromArgb(160, 175, 200);
            this.lblLoginPassword.Location = new Point(0, 156);
            this.lblLoginPassword.Size = new Size(200, 20);

            this.txtLoginPassword.Location = new Point(0, 178);
            this.txtLoginPassword.Size = new Size(380, 28);
            this.txtLoginPassword.Font = new Font("Segoe UI", 11);
            this.txtLoginPassword.BackColor = Color.FromArgb(28, 32, 50);
            this.txtLoginPassword.ForeColor = Color.FromArgb(200, 210, 230);
            this.txtLoginPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtLoginPassword.UseSystemPasswordChar = true;
            this.txtLoginPassword.PlaceholderText = "Enter your password";

            this.lblLoginError.Location = new Point(0, 224);
            this.lblLoginError.Size = new Size(500, 20);
            this.lblLoginError.ForeColor = Color.FromArgb(245, 101, 101);
            this.lblLoginError.Font = new Font("Segoe UI", 8.5f);

            this.btnLogin.Text = "Sign In  →";
            this.btnLogin.Location = new Point(0, 252);
            this.btnLogin.Size = new Size(180, 44);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.BackColor = Color.FromArgb(99, 179, 237);
            this.btnLogin.ForeColor = Color.FromArgb(15, 17, 26);
            this.btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Click += this.btnLogin_Click;

            this.lblLoginHint.Text = "Don't have an account? Click 'Register' above.";
            this.lblLoginHint.Font = new Font("Segoe UI", 8.5f);
            this.lblLoginHint.ForeColor = Color.FromArgb(110, 125, 160);
            this.lblLoginHint.Location = new Point(0, 312);
            this.lblLoginHint.Size = new Size(400, 20);

            this.pnlLoginInner.Controls.AddRange(new Control[]
            {
            this.lblLoginTitle, this.lblLoginSub,
            this.lblLoginUsername, this.txtLoginUsername,
            this.lblLoginPassword, this.txtLoginPassword,
            this.lblLoginError, this.btnLogin, this.lblLoginHint
            });
            this.tabLogin.Controls.Add(this.pnlLoginInner);

            // ── Register Tab ─────────────────────────────────────────────────────
            this.tabRegister.Text = "  Register  ";
            this.tabRegister.BackColor = Color.FromArgb(15, 17, 26);

            this.pnlRegInner.Dock = DockStyle.Fill;
            this.pnlRegInner.Padding = new Padding(30, 10, 30, 10);

            this.lblRegTitle.Text = "Create account";
            this.lblRegTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblRegTitle.ForeColor = Color.White;
            this.lblRegTitle.Location = new Point(0, 0);
            this.lblRegTitle.Size = new Size(500, 34);

            this.lblRegSub.Text = "Your files will be encrypted before storage";
            this.lblRegSub.Font = new Font("Segoe UI", 9);
            this.lblRegSub.ForeColor = Color.FromArgb(110, 125, 160);
            this.lblRegSub.Location = new Point(0, 36);
            this.lblRegSub.Size = new Size(500, 20);

            SetupRegField(this.lblRegUsername, this.txtRegUsername,
                "Username", "Min. 3 characters", 80, false);
            SetupRegField(this.lblRegEmail, this.txtRegEmail,
                "E-Mail", "your@email.com", 138, false);
            SetupRegField(this.lblRegPassword, this.txtRegPassword,
                "Password", "Min. 10 chars, upper, lower, digit, symbol", 196, true);
            SetupRegField(this.lblRegConfirm, this.txtRegConfirm,
                "Confirm Password", "Repeat password", 254, true);

            this.lblRegError.Location = new Point(0, 310);
            this.lblRegError.Size = new Size(500, 20);
            this.lblRegError.ForeColor = Color.FromArgb(245, 101, 101);
            this.lblRegError.Font = new Font("Segoe UI", 8.5f);

            this.lblRegSuccess.Location = new Point(0, 310);
            this.lblRegSuccess.Size = new Size(500, 20);
            this.lblRegSuccess.ForeColor = Color.FromArgb(72, 199, 142);
            this.lblRegSuccess.Font = new Font("Segoe UI", 8.5f);

            this.btnRegister.Text = "Create Account  →";
            this.btnRegister.Location = new Point(0, 336);
            this.btnRegister.Size = new Size(200, 44);
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.BackColor = Color.FromArgb(72, 199, 142);
            this.btnRegister.ForeColor = Color.FromArgb(15, 17, 26);
            this.btnRegister.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnRegister.Cursor = Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Click += this.btnRegister_Click;

            this.pnlRegInner.Controls.AddRange(new Control[]
            {
            this.lblRegTitle, this.lblRegSub,
            this.lblRegUsername, this.txtRegUsername,
            this.lblRegEmail,    this.txtRegEmail,
            this.lblRegPassword, this.txtRegPassword,
            this.lblRegConfirm,  this.txtRegConfirm,
            this.lblRegError,    this.lblRegSuccess,
            this.btnRegister
            });
            this.tabRegister.Controls.Add(this.pnlRegInner);

            // ── Assemble ─────────────────────────────────────────────────────────
            this.tabControl.TabPages.AddRange(new TabPage[] { this.tabLogin, this.tabRegister });
            this.pnlMain.Controls.Add(this.tabControl);

            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSide);

            this.ResumeLayout(false);
        }

        // ─── Designer helper methods ─────────────────────────────────────────────

        private static void BuildBulletRow(Panel pnl, Label icon, Label head, Label sub,
            int y, string emojiText, string headText, string subText)
        {
            pnl.Location = new Point(0, y);
            pnl.Size = new Size(270, 58);

            icon.Text = emojiText;
            icon.Font = new Font("Segoe UI Emoji", 16);
            icon.Location = new Point(0, 8);
            icon.Size = new Size(36, 40);

            head.Text = headText;
            head.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            head.ForeColor = Color.FromArgb(200, 210, 230);
            head.Location = new Point(44, 4);
            head.Size = new Size(220, 22);

            sub.Text = subText;
            sub.Font = new Font("Segoe UI", 8);
            sub.ForeColor = Color.FromArgb(110, 125, 160);
            sub.Location = new Point(44, 26);
            sub.Size = new Size(220, 20);

            pnl.Controls.AddRange(new Control[] { icon, head, sub });
        }

        private static void SetupRegField(Label lbl, TextBox txt,
            string labelText, string placeholder, int y, bool isPassword)
        {
            lbl.Text = labelText;
            lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(160, 175, 200);
            lbl.Location = new Point(0, y);
            lbl.Size = new Size(300, 20);

            txt.Location = new Point(0, y + 22);
            txt.Size = new Size(380, 28);
            txt.Font = new Font("Segoe UI", 11);
            txt.BackColor = Color.FromArgb(28, 32, 50);
            txt.ForeColor = Color.FromArgb(200, 210, 230);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.PlaceholderText = placeholder;
            txt.UseSystemPasswordChar = isPassword;
        }

        #endregion

        // ─── Designer control declarations ───────────────────────────────────────

        private Panel pnlSide;
        private Panel pnlLogo;
        private Label lblLogo;
        private Label lblAppTitle;
        private Panel pnlBullets;
        private Panel pnlBullet1;
        private Label lblBullet1Icon;
        private Label lblBullet1Head;
        private Label lblBullet1Sub;
        private Panel pnlBullet2;
        private Label lblBullet2Icon;
        private Label lblBullet2Head;
        private Label lblBullet2Sub;
        private Panel pnlBullet3;
        private Label lblBullet3Icon;
        private Label lblBullet3Head;
        private Label lblBullet3Sub;
        private Panel pnlBullet4;
        private Label lblBullet4Icon;
        private Label lblBullet4Head;
        private Label lblBullet4Sub;
        private Panel pnlMain;
        private TabControl tabControl;
        private TabPage tabLogin;
        private Panel pnlLoginInner;
        private Label lblLoginTitle;
        private Label lblLoginSub;
        private Label lblLoginUsername;
        private TextBox txtLoginUsername;
        private Label lblLoginPassword;
        private TextBox txtLoginPassword;
        private Label lblLoginError;
        private Button btnLogin;
        private Label lblLoginHint;
        private TabPage tabRegister;
        private Panel pnlRegInner;
        private Label lblRegTitle;
        private Label lblRegSub;
        private Label lblRegUsername;
        private TextBox txtRegUsername;
        private Label lblRegEmail;
        private TextBox txtRegEmail;
        private Label lblRegPassword;
        private TextBox txtRegPassword;
        private Label lblRegConfirm;
        private TextBox txtRegConfirm;
        private Label lblRegError;
        private Label lblRegSuccess;
        private Button btnRegister;
    }
}