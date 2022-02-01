using Microsoft.Extensions.DependencyInjection;
using SLS.Services.Interfaces;

namespace SLS.Services
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection RegistrationServices(this IServiceCollection services)
        {
            services.AddTransient<ILogger, ActionLogger>();

            return services;
        }
    }
}
