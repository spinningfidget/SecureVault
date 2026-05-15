namespace WinFormsApp2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pnlSide = new Panel();
            pnlBullets = new Panel();
            pnlBullet1 = new Panel();
            pnlBullet2 = new Panel();
            pnlBullet3 = new Panel();
            pnlBullet4 = new Panel();
            pnlLogo = new Panel();
            lblAppTitle = new Label();
            lblLogo = new Label();
            lblBullet1Icon = new Label();
            lblBullet1Head = new Label();
            lblBullet1Sub = new Label();
            lblBullet2Icon = new Label();
            lblBullet2Head = new Label();
            lblBullet2Sub = new Label();
            lblBullet3Icon = new Label();
            lblBullet3Head = new Label();
            lblBullet3Sub = new Label();
            lblBullet4Icon = new Label();
            lblBullet4Head = new Label();
            lblBullet4Sub = new Label();
            pnlMain = new Panel();
            tabControl = new TabControl();
            tabLogin = new TabPage();
            pnlLoginInner = new Panel();
            lblLoginTitle = new Label();
            lblLoginSub = new Label();
            lblLoginUsername = new Label();
            txtLoginUsername = new TextBox();
            lblLoginPassword = new Label();
            txtLoginPassword = new TextBox();
            lblLoginError = new Label();
            btnLogin = new Button();
            lblLoginHint = new Label();
            tabRegister = new TabPage();
            pnlRegInner = new Panel();
            lblRegTitle = new Label();
            lblRegSub = new Label();
            lblRegUsername = new Label();
            txtRegUsername = new TextBox();
            lblRegEmail = new Label();
            txtRegEmail = new TextBox();
            lblRegPassword = new Label();
            txtRegPassword = new TextBox();
            lblRegConfirm = new Label();
            txtRegConfirm = new TextBox();
            lblRegError = new Label();
            lblRegSuccess = new Label();
            btnRegister = new Button();
            btnEye = new PictureBox();
            pnlSide.SuspendLayout();
            pnlBullets.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlMain.SuspendLayout();
            tabControl.SuspendLayout();
            tabLogin.SuspendLayout();
            pnlLoginInner.SuspendLayout();
            tabRegister.SuspendLayout();
            pnlRegInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnEye).BeginInit();
            SuspendLayout();
            // 
            // pnlSide
            // 
            pnlSide.BackColor = Color.FromArgb(20, 22, 35);
            pnlSide.Controls.Add(pnlBullets);
            pnlSide.Controls.Add(pnlLogo);
            pnlSide.Dock = DockStyle.Left;
            pnlSide.Location = new Point(0, 0);
            pnlSide.Name = "pnlSide";
            pnlSide.Size = new Size(320, 581);
            pnlSide.TabIndex = 1;
            // 
            // pnlBullets
            // 
            pnlBullets.Controls.Add(pnlBullet1);
            pnlBullets.Controls.Add(pnlBullet2);
            pnlBullets.Controls.Add(pnlBullet3);
            pnlBullets.Controls.Add(pnlBullet4);
            pnlBullets.Dock = DockStyle.Fill;
            pnlBullets.Location = new Point(0, 180);
            pnlBullets.Name = "pnlBullets";
            pnlBullets.Padding = new Padding(24, 20, 24, 0);
            pnlBullets.Size = new Size(320, 401);
            pnlBullets.TabIndex = 0;
            // 
            // pnlBullet1
            // 
            pnlBullet1.Location = new Point(0, 0);
            pnlBullet1.Name = "pnlBullet1";
            pnlBullet1.Size = new Size(200, 100);
            pnlBullet1.TabIndex = 0;
            // 
            // pnlBullet2
            // 
            pnlBullet2.Location = new Point(0, 0);
            pnlBullet2.Name = "pnlBullet2";
            pnlBullet2.Size = new Size(200, 100);
            pnlBullet2.TabIndex = 1;
            // 
            // pnlBullet3
            // 
            pnlBullet3.Location = new Point(0, 0);
            pnlBullet3.Name = "pnlBullet3";
            pnlBullet3.Size = new Size(200, 100);
            pnlBullet3.TabIndex = 2;
            // 
            // pnlBullet4
            // 
            pnlBullet4.Location = new Point(0, 0);
            pnlBullet4.Name = "pnlBullet4";
            pnlBullet4.Size = new Size(200, 100);
            pnlBullet4.TabIndex = 3;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(30, 34, 54);
            pnlLogo.Controls.Add(lblAppTitle);
            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(320, 180);
            pnlLogo.TabIndex = 1;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Dock = DockStyle.Fill;
            lblAppTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.FromArgb(99, 179, 237);
            lblAppTitle.Location = new Point(0, 100);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(320, 80);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "SecureVault";
            lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI Emoji", 42F);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(320, 100);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "🔐";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBullet1Icon
            // 
            lblBullet1Icon.Location = new Point(0, 0);
            lblBullet1Icon.Name = "lblBullet1Icon";
            lblBullet1Icon.Size = new Size(100, 23);
            lblBullet1Icon.TabIndex = 0;
            // 
            // lblBullet1Head
            // 
            lblBullet1Head.Location = new Point(0, 0);
            lblBullet1Head.Name = "lblBullet1Head";
            lblBullet1Head.Size = new Size(100, 23);
            lblBullet1Head.TabIndex = 0;
            // 
            // lblBullet1Sub
            // 
            lblBullet1Sub.Location = new Point(0, 0);
            lblBullet1Sub.Name = "lblBullet1Sub";
            lblBullet1Sub.Size = new Size(100, 23);
            lblBullet1Sub.TabIndex = 0;
            // 
            // lblBullet2Icon
            // 
            lblBullet2Icon.Location = new Point(0, 0);
            lblBullet2Icon.Name = "lblBullet2Icon";
            lblBullet2Icon.Size = new Size(100, 23);
            lblBullet2Icon.TabIndex = 0;
            // 
            // lblBullet2Head
            // 
            lblBullet2Head.Location = new Point(0, 0);
            lblBullet2Head.Name = "lblBullet2Head";
            lblBullet2Head.Size = new Size(100, 23);
            lblBullet2Head.TabIndex = 0;
            // 
            // lblBullet2Sub
            // 
            lblBullet2Sub.Location = new Point(0, 0);
            lblBullet2Sub.Name = "lblBullet2Sub";
            lblBullet2Sub.Size = new Size(100, 23);
            lblBullet2Sub.TabIndex = 0;
            // 
            // lblBullet3Icon
            // 
            lblBullet3Icon.Location = new Point(0, 0);
            lblBullet3Icon.Name = "lblBullet3Icon";
            lblBullet3Icon.Size = new Size(100, 23);
            lblBullet3Icon.TabIndex = 0;
            // 
            // lblBullet3Head
            // 
            lblBullet3Head.Location = new Point(0, 0);
            lblBullet3Head.Name = "lblBullet3Head";
            lblBullet3Head.Size = new Size(100, 23);
            lblBullet3Head.TabIndex = 0;
            // 
            // lblBullet3Sub
            // 
            lblBullet3Sub.Location = new Point(0, 0);
            lblBullet3Sub.Name = "lblBullet3Sub";
            lblBullet3Sub.Size = new Size(100, 23);
            lblBullet3Sub.TabIndex = 0;
            // 
            // lblBullet4Icon
            // 
            lblBullet4Icon.Location = new Point(0, 0);
            lblBullet4Icon.Name = "lblBullet4Icon";
            lblBullet4Icon.Size = new Size(100, 23);
            lblBullet4Icon.TabIndex = 0;
            // 
            // lblBullet4Head
            // 
            lblBullet4Head.Location = new Point(0, 0);
            lblBullet4Head.Name = "lblBullet4Head";
            lblBullet4Head.Size = new Size(100, 23);
            lblBullet4Head.TabIndex = 0;
            // 
            // lblBullet4Sub
            // 
            lblBullet4Sub.Location = new Point(0, 0);
            lblBullet4Sub.Name = "lblBullet4Sub";
            lblBullet4Sub.Size = new Size(100, 23);
            lblBullet4Sub.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(15, 17, 26);
            pnlMain.Controls.Add(tabControl);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(320, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(40);
            pnlMain.Size = new Size(564, 581);
            pnlMain.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.Controls.Add(tabLogin);
            tabControl.Controls.Add(tabRegister);
            tabControl.Dock = DockStyle.Fill;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.ItemSize = new Size(130, 36);
            tabControl.Location = new Point(40, 40);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(484, 501);
            tabControl.TabIndex = 0;
            tabControl.DrawItem += tabControl_DrawItem;
            // 
            // tabLogin
            // 
            tabLogin.BackColor = Color.FromArgb(15, 17, 26);
            tabLogin.Controls.Add(pnlLoginInner);
            tabLogin.Location = new Point(4, 40);
            tabLogin.Name = "tabLogin";
            tabLogin.Size = new Size(476, 457);
            tabLogin.TabIndex = 0;
            tabLogin.Text = "  Sign In  ";
            // 
            // pnlLoginInner
            // 
            pnlLoginInner.Controls.Add(btnEye);
            pnlLoginInner.Controls.Add(lblLoginTitle);
            pnlLoginInner.Controls.Add(lblLoginSub);
            pnlLoginInner.Controls.Add(lblLoginUsername);
            pnlLoginInner.Controls.Add(txtLoginUsername);
            pnlLoginInner.Controls.Add(lblLoginPassword);
            pnlLoginInner.Controls.Add(txtLoginPassword);
            pnlLoginInner.Controls.Add(lblLoginError);
            pnlLoginInner.Controls.Add(btnLogin);
            pnlLoginInner.Controls.Add(lblLoginHint);
            pnlLoginInner.Dock = DockStyle.Fill;
            pnlLoginInner.Location = new Point(0, 0);
            pnlLoginInner.Name = "pnlLoginInner";
            pnlLoginInner.Padding = new Padding(30, 20, 30, 20);
            pnlLoginInner.Size = new Size(476, 457);
            pnlLoginInner.TabIndex = 0;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLoginTitle.ForeColor = Color.White;
            lblLoginTitle.Location = new Point(0, 0);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(500, 34);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "Welcome back";
            // 
            // lblLoginSub
            // 
            lblLoginSub.Font = new Font("Segoe UI", 9F);
            lblLoginSub.ForeColor = Color.FromArgb(110, 125, 160);
            lblLoginSub.Location = new Point(0, 38);
            lblLoginSub.Name = "lblLoginSub";
            lblLoginSub.Size = new Size(500, 20);
            lblLoginSub.TabIndex = 1;
            lblLoginSub.Text = "Sign in to access your encrypted vault";
            // 
            // lblLoginUsername
            // 
            lblLoginUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLoginUsername.ForeColor = Color.FromArgb(160, 175, 200);
            lblLoginUsername.Location = new Point(0, 90);
            lblLoginUsername.Name = "lblLoginUsername";
            lblLoginUsername.Size = new Size(200, 20);
            lblLoginUsername.TabIndex = 2;
            lblLoginUsername.Text = "Username";
            // 
            // txtLoginUsername
            // 
            txtLoginUsername.BackColor = Color.FromArgb(28, 32, 50);
            txtLoginUsername.BorderStyle = BorderStyle.FixedSingle;
            txtLoginUsername.Font = new Font("Segoe UI", 11F);
            txtLoginUsername.ForeColor = Color.FromArgb(200, 210, 230);
            txtLoginUsername.Location = new Point(0, 112);
            txtLoginUsername.Name = "txtLoginUsername";
            txtLoginUsername.PlaceholderText = "Enter your username";
            txtLoginUsername.Size = new Size(380, 27);
            txtLoginUsername.TabIndex = 3;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLoginPassword.ForeColor = Color.FromArgb(160, 175, 200);
            lblLoginPassword.Location = new Point(0, 156);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(200, 20);
            lblLoginPassword.TabIndex = 4;
            lblLoginPassword.Text = "Password";
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.BackColor = Color.FromArgb(28, 32, 50);
            txtLoginPassword.BorderStyle = BorderStyle.FixedSingle;
            txtLoginPassword.Font = new Font("Segoe UI", 11F);
            txtLoginPassword.ForeColor = Color.FromArgb(200, 210, 230);
            txtLoginPassword.Location = new Point(0, 178);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.PlaceholderText = "Enter your password";
            txtLoginPassword.Size = new Size(380, 27);
            txtLoginPassword.TabIndex = 5;
            txtLoginPassword.UseSystemPasswordChar = true;
            // 
            // lblLoginError
            // 
            lblLoginError.Font = new Font("Segoe UI", 8.5F);
            lblLoginError.ForeColor = Color.FromArgb(245, 101, 101);
            lblLoginError.Location = new Point(0, 224);
            lblLoginError.Name = "lblLoginError";
            lblLoginError.Size = new Size(500, 20);
            lblLoginError.TabIndex = 6;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(99, 179, 237);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.FromArgb(15, 17, 26);
            btnLogin.Location = new Point(0, 252);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(180, 44);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Sign In  →";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblLoginHint
            // 
            lblLoginHint.Font = new Font("Segoe UI", 8.5F);
            lblLoginHint.ForeColor = Color.FromArgb(110, 125, 160);
            lblLoginHint.Location = new Point(0, 312);
            lblLoginHint.Name = "lblLoginHint";
            lblLoginHint.Size = new Size(400, 20);
            lblLoginHint.TabIndex = 8;
            lblLoginHint.Text = "Don't have an account? Click 'Register' above.";
            // 
            // tabRegister
            // 
            tabRegister.BackColor = Color.FromArgb(15, 17, 26);
            tabRegister.Controls.Add(pnlRegInner);
            tabRegister.Location = new Point(4, 40);
            tabRegister.Name = "tabRegister";
            tabRegister.Size = new Size(112, 0);
            tabRegister.TabIndex = 1;
            tabRegister.Text = "  Register  ";
            // 
            // pnlRegInner
            // 
            pnlRegInner.Controls.Add(lblRegTitle);
            pnlRegInner.Controls.Add(lblRegSub);
            pnlRegInner.Controls.Add(lblRegUsername);
            pnlRegInner.Controls.Add(txtRegUsername);
            pnlRegInner.Controls.Add(lblRegEmail);
            pnlRegInner.Controls.Add(txtRegEmail);
            pnlRegInner.Controls.Add(lblRegPassword);
            pnlRegInner.Controls.Add(txtRegPassword);
            pnlRegInner.Controls.Add(lblRegConfirm);
            pnlRegInner.Controls.Add(txtRegConfirm);
            pnlRegInner.Controls.Add(lblRegError);
            pnlRegInner.Controls.Add(lblRegSuccess);
            pnlRegInner.Controls.Add(btnRegister);
            pnlRegInner.Dock = DockStyle.Fill;
            pnlRegInner.Location = new Point(0, 0);
            pnlRegInner.Name = "pnlRegInner";
            pnlRegInner.Padding = new Padding(30, 10, 30, 10);
            pnlRegInner.Size = new Size(112, 0);
            pnlRegInner.TabIndex = 0;
            // 
            // lblRegTitle
            // 
            lblRegTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblRegTitle.ForeColor = Color.White;
            lblRegTitle.Location = new Point(0, 0);
            lblRegTitle.Name = "lblRegTitle";
            lblRegTitle.Size = new Size(500, 34);
            lblRegTitle.TabIndex = 0;
            lblRegTitle.Text = "Create account";
            // 
            // lblRegSub
            // 
            lblRegSub.Font = new Font("Segoe UI", 9F);
            lblRegSub.ForeColor = Color.FromArgb(110, 125, 160);
            lblRegSub.Location = new Point(0, 36);
            lblRegSub.Name = "lblRegSub";
            lblRegSub.Size = new Size(500, 20);
            lblRegSub.TabIndex = 1;
            lblRegSub.Text = "Your files will be encrypted before storage";
            // 
            // lblRegUsername
            // 
            lblRegUsername.Location = new Point(0, 0);
            lblRegUsername.Name = "lblRegUsername";
            lblRegUsername.Size = new Size(100, 23);
            lblRegUsername.TabIndex = 2;
            // 
            // txtRegUsername
            // 
            txtRegUsername.Location = new Point(0, 0);
            txtRegUsername.Name = "txtRegUsername";
            txtRegUsername.Size = new Size(100, 25);
            txtRegUsername.TabIndex = 3;
            // 
            // lblRegEmail
            // 
            lblRegEmail.Location = new Point(0, 0);
            lblRegEmail.Name = "lblRegEmail";
            lblRegEmail.Size = new Size(100, 23);
            lblRegEmail.TabIndex = 4;
            // 
            // txtRegEmail
            // 
            txtRegEmail.Location = new Point(0, 0);
            txtRegEmail.Name = "txtRegEmail";
            txtRegEmail.Size = new Size(100, 25);
            txtRegEmail.TabIndex = 5;
            // 
            // lblRegPassword
            // 
            lblRegPassword.Location = new Point(0, 0);
            lblRegPassword.Name = "lblRegPassword";
            lblRegPassword.Size = new Size(100, 23);
            lblRegPassword.TabIndex = 6;
            // 
            // txtRegPassword
            // 
            txtRegPassword.Location = new Point(0, 0);
            txtRegPassword.Name = "txtRegPassword";
            txtRegPassword.Size = new Size(100, 25);
            txtRegPassword.TabIndex = 7;
            // 
            // lblRegConfirm
            // 
            lblRegConfirm.Location = new Point(0, 0);
            lblRegConfirm.Name = "lblRegConfirm";
            lblRegConfirm.Size = new Size(100, 23);
            lblRegConfirm.TabIndex = 8;
            // 
            // txtRegConfirm
            // 
            txtRegConfirm.Location = new Point(0, 0);
            txtRegConfirm.Name = "txtRegConfirm";
            txtRegConfirm.Size = new Size(100, 25);
            txtRegConfirm.TabIndex = 9;
            // 
            // lblRegError
            // 
            lblRegError.Font = new Font("Segoe UI", 8.5F);
            lblRegError.ForeColor = Color.FromArgb(245, 101, 101);
            lblRegError.Location = new Point(0, 310);
            lblRegError.Name = "lblRegError";
            lblRegError.Size = new Size(500, 20);
            lblRegError.TabIndex = 10;
            // 
            // lblRegSuccess
            // 
            lblRegSuccess.Font = new Font("Segoe UI", 8.5F);
            lblRegSuccess.ForeColor = Color.FromArgb(72, 199, 142);
            lblRegSuccess.Location = new Point(0, 310);
            lblRegSuccess.Name = "lblRegSuccess";
            lblRegSuccess.Size = new Size(500, 20);
            lblRegSuccess.TabIndex = 11;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(72, 199, 142);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegister.ForeColor = Color.FromArgb(15, 17, 26);
            btnRegister.Location = new Point(0, 336);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(200, 44);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Create Account  →";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnEye
            // 
            btnEye.Image = (Image)resources.GetObject("btnEye.Image");
            btnEye.Location = new Point(386, 178);
            btnEye.Name = "btnEye";
            btnEye.Size = new Size(26, 27);
            btnEye.SizeMode = PictureBoxSizeMode.Zoom;
            btnEye.TabIndex = 9;
            btnEye.TabStop = false;
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(15, 17, 26);
            ClientSize = new Size(884, 581);
            Controls.Add(pnlMain);
            Controls.Add(pnlSide);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(900, 620);
            MinimumSize = new Size(900, 620);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SecureVault — Secure File Storage";
            pnlSide.ResumeLayout(false);
            pnlBullets.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabLogin.ResumeLayout(false);
            pnlLoginInner.ResumeLayout(false);
            pnlLoginInner.PerformLayout();
            tabRegister.ResumeLayout(false);
            pnlRegInner.ResumeLayout(false);
            pnlRegInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnEye).EndInit();
            ResumeLayout(false);
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
        private PictureBox btnEye;
    }
}