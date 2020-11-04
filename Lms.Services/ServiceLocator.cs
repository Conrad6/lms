using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace Lms.Services
{
    public delegate void ServiceInitializeSubscription(IServiceCollection serviceCollection);
    public static class ServiceLocator
    {
        private static ServiceProvider _serviceProvider;
        private static bool _initialized;
        public static ServiceInitializeSubscription InitRegistry;

        public static void Initialize(IServiceCollection services)
        {
            if (_initialized) return;

            _initialized = true;
            if(services is null) throw new ArgumentNullException(nameof(services));
            InitRegistry?.Invoke(services);
            services.AddSingleton<PasswordEncoder>();
            services.AddSingleton<UserClientService>();
            services.AddSingleton<BookClientService>();
            services.AddSingleton<StockClientService>();
            services.AddLogging(builder =>
            {
                builder.AddFilter(level => level == LogLevel.Critical);
                builder.AddFilter(level => level == LogLevel.Information);
                builder.AddFilter(level => level == LogLevel.Error);
                builder.AddFilter(level => level == LogLevel.Warning);
            });
            _serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => _serviceProvider.GetService<T>();
    }
}