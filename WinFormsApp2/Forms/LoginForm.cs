using SecureVault.Models;
using SecureVault.Services;
using Timer = System.Windows.Forms.Timer;

namespace SecureVault.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public User? LoggedInUser { get; private set; }
        public string? LoggedInPassword { get; private set; }
        private readonly Timer _hideTimer = new();

        public LoginForm(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
            // Password textbox
            txtLoginPassword.UseSystemPasswordChar = true;

            // Timer setup
            _hideTimer.Interval = 3000; // 3 seconds
            _hideTimer.Tick += HideTimer_Tick;

            // Eye button events
            btnEye.MouseDown += BtnEye_MouseDown;
            btnEye.MouseUp += BtnEye_MouseUp;
            btnEye.MouseLeave += BtnEye_MouseLeave;
            
            
            // Ensure register tab is laid out properly
            tabRegister.Size = tabLogin.Size;

            // Setup register fields layout + styling
            SetupRegField(lblRegUsername, txtRegUsername, "Username", "Choose a username", 90, false);
            SetupRegField(lblRegEmail,    txtRegEmail,    "Email",    "Enter your email",   156, false);
            SetupRegField(lblRegPassword, txtRegPassword, "Password", "Create a password", 222, true);
            SetupRegField(lblRegConfirm,  txtRegConfirm,  "Confirm",  "Repeat password",   288, true);

            // optional: align button below fields
            btnRegister.Location = new Point(0, 350);

        }

        // ─── Tab owner-draw ───────────────────────────────────────────────────────

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool selected = e.Index == tabControl.SelectedIndex;
            Color bgColor = selected ? Color.FromArgb(99, 179, 237) : Color.FromArgb(30, 34, 54);
            Color fgColor = selected ? Color.FromArgb(15, 17, 26) : Color.FromArgb(140, 155, 185);

            using var bg = new SolidBrush(bgColor);
            e.Graphics.FillRectangle(bg, e.Bounds);

            using var fg = new SolidBrush(fgColor);
            string text = tabControl.TabPages[e.Index].Text;
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(text, new Font("Segoe UI", 10, FontStyle.Bold), fg, e.Bounds, sf);
        }

        // ─── Login tab ───────────────────────────────────────────────────────────        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblLoginError.Text = string.Empty;

            var user = _userService.Login(txtLoginUsername.Text, txtLoginPassword.Text);
            if (user == null)
            {
                lblLoginError.Text = @"⚠ Invalid username or password.";
                txtLoginPassword.Clear();
                return;
            }

            LoggedInUser = user;
            LoggedInPassword = txtLoginPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        // Show password when mouse is pressed
        private void BtnEye_MouseDown(object? sender, MouseEventArgs e)
        {
            ShowPassword();

            // Restart timer every time user presses
            _hideTimer.Stop();
            _hideTimer.Start();
        }
        // Hide immediately when released
        private void BtnEye_MouseUp(object? sender, MouseEventArgs e)
        {
            HidePassword();
        }

        // Extra protection if cursor leaves button
        private void BtnEye_MouseLeave(object? sender, EventArgs e)
        {
            HidePassword();
        }

        // Auto-hide after timeout
        private void HideTimer_Tick(object? sender, EventArgs e)
        {
            HidePassword();
            _hideTimer.Stop();
        }

        private void ShowPassword()
        {
            txtLoginPassword.UseSystemPasswordChar = false;

            // Optional:
            // btnEye.Image = Properties.Resources.eye_open;
        }

        private void HidePassword()
        {
            txtLoginPassword.UseSystemPasswordChar = true;

            // Optional:
            // btnEye.Image = Properties.Resources.eye_closed;

            _hideTimer.Stop();
        }
        // ─── Register tab ────────────────────────────────────────────────────────

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            lblRegError.Text = string.Empty;
            lblRegSuccess.Text = string.Empty;

            if (txtRegPassword.Text != txtRegConfirm.Text)
            {
                lblRegError.Text = @"⚠  Passwords do not match.";
                return;
            }

            var (ok, err) = _userService.Register(
                txtRegUsername.Text,
                txtRegEmail.Text,
                txtRegPassword.Text);

            if (!ok)
            {
                lblRegError.Text = $@"⚠  {err}";
                return;
            }

            lblRegSuccess.Text = @"✓  Account created! You can now sign in.";
            txtRegUsername.Clear();
            txtRegEmail.Clear();
            txtRegPassword.Clear();
            txtRegConfirm.Clear();
            tabControl.SelectedIndex = 0;
        }
    }
}
