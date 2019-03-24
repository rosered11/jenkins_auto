using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DemoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args);
            var culture = new System.Globalization.CultureInfo("en-US");
            Directory.SetCurrentDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
            
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(ConfigBuilder)
                .CreateLogger();
            
            try
            {
                webHost.Build().Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "The main exception.");
            }
            Log.CloseAndFlush();
        }

        public static IConfiguration ConfigBuilder => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(ConfigBuilder)
                .UseStartup<Startup>();
    }
}
