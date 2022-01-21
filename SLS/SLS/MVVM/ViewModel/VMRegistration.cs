using Microsoft.Extensions.DependencyInjection;

namespace SLS.MVVM.ViewModel
{
    internal static class VMRegistration
    {
        public static IServiceCollection RegistrationViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainVM>();
            services.AddSingleton<HomeVM>();
            services.AddSingleton<ResourcesListVM>();

            return services;
        }
    }
}
