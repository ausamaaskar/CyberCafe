using CyberCafe.Forms;
using Google.Cloud.Firestore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CyberCafe
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Build configuration for future use
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Setup DI container for forms that use dependency injection
            var services = new ServiceCollection();
            ConfigureServices(services, configuration);
            var serviceProvider = services.BuildServiceProvider();

            // Determine which form to run based on configuration
            // Using legacy ConfigurationManager for backward compatibility
            var isAdminConsole = ConfigurationManager.AppSettings["Admin"];
            if (Convert.ToBoolean(isAdminConsole))
            {
                Application.Run(new AdminPanel());
            }
            else
            {
                Application.Run(new ClientApplication());
            }
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register configuration
            services.AddSingleton(configuration);

            // Register FirestoreController as singleton
            services.AddSingleton<IFirestoreController>(sp =>
            {
                var projectId = configuration["ProjectId"];
                var authPath = configuration["AuthenticationPath"];
                return new FirestoreController(projectId, authPath);
            });

            // Register forms that use DI as transient
            services.AddTransient<Booking>();
            services.AddTransient<NewRoom>();
        }
    }
}