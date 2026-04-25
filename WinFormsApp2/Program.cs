using WinFormsApp2.Services;

namespace WinFormsApp2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            var userService = new UserService();

            while (true)
            {
                using var loginForm = new LoginForm(userService);
                if (loginForm.ShowDialog() != DialogResult.OK) break;

                var user = loginForm.LoggedInUser!;
                var password = loginForm.LoggedInPassword!;

                var vaultService = new VaultService(user, password);

                using var dashboard = new DashboardForm(user, vaultService);
                var result = dashboard.ShowDialog();

                // DialogResult.Retry = user clicked Sign Out → loop back to login
                if (result != DialogResult.Retry) break;
            }
        }
    }
}