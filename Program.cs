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

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Setup DI container
            var services = new ServiceCollection();
            ConfigureServices(services, configuration);
            var serviceProvider = services.BuildServiceProvider();

            // Determine which form to run based on configuration
            var isAdmin = configuration["Admin"];
            if (!string.IsNullOrEmpty(isAdmin) && Convert.ToBoolean(isAdmin))
            {
                var adminPanel = serviceProvider.GetRequiredService<AdminPanel>();
                Application.Run(adminPanel);
            }
            else
            {
                var clientApp = serviceProvider.GetRequiredService<ClientApplication>();
                Application.Run(clientApp);
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

            // Register forms as transient
            services.AddTransient<AdminPanel>();
            services.AddTransient<ClientApplication>();
            services.AddTransient<Booking>();
            services.AddTransient<NewRoom>();
        }
    }
}