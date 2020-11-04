using System.Windows.Navigation;
using Lms.Data;
using Lms.Desktop.Pages;
using Lms.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Lms.Desktop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<NavigationWindow>();
            services.AddSingleton<MainApplication>();
            services.AddSingleton<LmsContext>();

            services.AddTransient(provider =>
                provider.GetService<NavigationWindow>().NavigationService);
            services.AddTransient<LoginPage>();
            services.AddTransient<BooksPage>();
            services.AddTransient<LoginViewModel>();
        }
    }
}