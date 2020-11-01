using System;
using Microsoft.Extensions.DependencyInjection;

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
            _serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => _serviceProvider.GetService<T>();
    }
}