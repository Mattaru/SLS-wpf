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

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            builder.UseContentRoot(Environment.CurrentDirectory);
            builder.ConfigureAppConfiguration((host, cfg) => 
            {
                cfg.SetBasePath(Environment.CurrentDirectory);
                cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            });

            builder.ConfigureServices(App.ConfigureServices);

            return builder;
        }
    }
}
