using Microsoft.Extensions.DependencyInjection;

namespace SLS.MVVM.ViewModel
{
    internal class ViewModelLocator
    {
        public MainVM MainViewModel => App.Host.Services.GetRequiredService<MainVM>();

        public HomeVM HomeViewModel => App.Host.Services.GetRequiredService<HomeVM>();

        public ResourcesListVM ResourcesListViewModel => App.Host.Services.GetRequiredService<ResourcesListVM>();
    }
}
