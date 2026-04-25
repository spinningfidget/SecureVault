using WinFormsApp2.Models;
using WinFormsApp2.Services;

namespace WinFormsApp2
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public User? LoggedInUser { get; private set; }
        public string? LoggedInPassword { get; private set; }

        public LoginForm(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
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
                lblLoginError.Text = "⚠  Invalid username or password.";
                txtLoginPassword.Clear();
                return;
            }

            LoggedInUser = user;
            LoggedInPassword = txtLoginPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        // ─── Register tab ────────────────────────────────────────────────────────

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblRegError.Text = string.Empty;
            lblRegSuccess.Text = string.Empty;

            if (txtRegPassword.Text != txtRegConfirm.Text)
            {
                lblRegError.Text = "⚠  Passwords do not match.";
                return;
            }

            var (ok, err) = _userService.Register(
                txtRegUsername.Text,
                txtRegEmail.Text,
                txtRegPassword.Text);

            if (!ok)
            {
                lblRegError.Text = $"⚠  {err}";
                return;
            }

            lblRegSuccess.Text = "✓  Account created! You can now sign in.";
            txtRegUsername.Clear();
            txtRegEmail.Clear();
            txtRegPassword.Clear();
            txtRegConfirm.Clear();
            tabControl.SelectedIndex = 0;
        }
    }
}
