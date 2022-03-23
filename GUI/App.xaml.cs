using DirectoryWatcher;
using GUI.Model;
using GUI.View;
using GUI.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        public static IServiceProvider ServiceProvider { get; set; }
        public App()
        {
            _host = new HostBuilder()
                .ConfigureAppConfiguration((context, configurationBuilder) =>
                {
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                    configurationBuilder.Build();
                })
                .ConfigureServices((hostContext, services)=>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    services.Configure<FolderPathsOptions>(
                    configuration.GetSection(FolderPathsOptions.FolderPaths));
                    services.AddHostedService<WindowsBackgroundService>();
                    services.AddSingleton<WatcherService>();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddDebug();
                })
                .Build();
            ServiceProvider = _host.Services;
        }
        private async void Application_Startup(object sender, StartupEventArgs e)
        {

            await _host.StartAsync();
            Window startWindow = _host.Services.GetService<MainWindow>();
            startWindow.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}
