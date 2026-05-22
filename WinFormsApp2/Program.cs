using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using SecureVault.Forms;
using SecureVault.Services;

namespace SecureVault
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            
            Log.Logger = new LoggerConfiguration().MinimumLevel.Information().Enrich.FromLogContext()
                .WriteTo.File(
                    path: Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "SecureVault",
                        "Logs",
                        "app-.log"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30)
                .CreateLogger();
            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddSerilog(Log.Logger, dispose: true);
            });

            services.AddSingleton<UserService>();
            services.AddTransient<LoginForm>();
            services.AddTransient<DashboardForm>();
            services.AddTransient<VaultService>();

            using var provider = services.BuildServiceProvider();

            while (true)
            {
                using var loginForm = provider.GetRequiredService<LoginForm>();
                if (loginForm.ShowDialog() != DialogResult.OK)
                    break;

                var user = loginForm.LoggedInUser!;
                var password = loginForm.LoggedInPassword!;

                using var scope = provider.CreateScope();
                var vaultService = new VaultService(user, password);

                using var dashboard = new DashboardForm(user, vaultService);
                var result = dashboard.ShowDialog();

                if (result != DialogResult.Retry)
                    break;
            }
            Log.CloseAndFlush();
        }
    }
}