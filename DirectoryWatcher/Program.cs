using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryWatcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    //var options = new FolderPathsOptions();
                    //configuration.GetSection(FolderPathsOptions.FolderPaths).Bind(options);
                    services.Configure<FolderPathsOptions>(
                        configuration.GetSection(FolderPathsOptions.FolderPaths));
                    services.AddHostedService<WindowsBackgroundService>();
                    services.AddSingleton<WatcherService>();
                });
                
    }
}
