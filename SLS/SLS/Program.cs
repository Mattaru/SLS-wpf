using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace SLS
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => 
            Host.CreateDefaultBuilder(args)
                .UseContentRoot(App.CurrentDirectory)
                .ConfigureAppConfiguration((host, cfg) => cfg
                    .SetBasePath(App.CurrentDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true))
                .ConfigureServices(App.ConfigureServices);
    }
}
