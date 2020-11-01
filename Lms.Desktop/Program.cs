using System;
using System.Windows;
using Lms.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lms.Desktop
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var services = new ServiceCollection();
            var startup = new Startup();
            ServiceLocator.InitRegistry += startup.ConfigureServices;
            ServiceLocator.Initialize(services);
            var app = ServiceLocator.Resolve<MainApplication>();
            app.Startup += (sender, args) =>
            {
                var mainWindow = (sender as Application)?.MainWindow;
                mainWindow?.Show();
            };
            app.Run();
        }
    }
}