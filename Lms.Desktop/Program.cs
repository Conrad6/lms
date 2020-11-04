using System;
using System.Linq;
using System.Windows;
using Bogus;
using Bogus.DataSets;
using Lms.Core;
using Lms.Data;
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
            /*var passwordEncoder = ServiceLocator.Resolve<PasswordEncoder>();
            var user = new User()
            {
                Email = "philllittle302@gmail.com",
                Gender = "Male",
                Password = passwordEncoder.HashPassword("deadpool672"),
                Phone = "654020651",
                Username = "conrad",
                FirstName = "Conrad",
                LastName = "Bekondo",
                UserRole = "Admin",
                Id = Guid.NewGuid().ToString()
            };

            var db = ServiceLocator.Resolve<LmsContext>();
            db.Users.Add(user);
            db.SaveChanges();*/
            
            app.Run();
        }
    }
} /*[0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]**/