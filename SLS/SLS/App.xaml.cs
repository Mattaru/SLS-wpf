using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SLS.MVVM.ViewModel;
using System.Windows;

namespace SLS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesignMode { get; private set; } = true;



        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;
            base.OnStartup(e);
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<HomeVM>();
            services.AddSingleton<ResourcesListVM>();
        }
    }
}
