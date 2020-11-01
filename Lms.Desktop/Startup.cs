using System.Windows.Navigation;
using Lms.Desktop.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace Lms.Desktop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<NavigationWindow>();
            services.AddTransient(provider =>
                provider.GetService<NavigationWindow>().NavigationService);
            services.AddSingleton<MainApplication>();

            services.AddTransient<LoginPage>();
        }
    }
}