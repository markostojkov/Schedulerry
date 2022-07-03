using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Schedulerry.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    string defaultAppSettingsFile = "appsettings.json";

#if DEBUG
                    string appSettingsFileToAdd = "appsettings.Development.json";
#else
                    string appSettingsFileToAdd = "appsettings.Debug.json";
#endif
                    config
                        .AddJsonFile(
                            defaultAppSettingsFile,
                            false,
                            true)
                        .AddJsonFile(
                            appSettingsFileToAdd,
                            true,
                            true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
