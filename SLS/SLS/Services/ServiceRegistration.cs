using Microsoft.Extensions.DependencyInjection;
using SLS.Services.Interfaces;
using SLS.Services.Repositorys;

namespace SLS.Services
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection RegistrationServices(this IServiceCollection services)
        {
            services.AddTransient<ILogger, ActionLogger>();

            services.AddSingleton<LoggsRepository>();
            services.AddSingleton<ResourcesRepository>();

            return services;
        }
    }
}
