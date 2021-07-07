
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace PL.ASP.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            //CreateHostBuilder(args).Build().Run();
            
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)//Serilog.Settings.Configuration
                //.WriteTo.Console()
                .CreateLogger();
            try
            {
                Log.Information("Application is starting... // Hello from Yuri Demydko!");
                CreateHostBuilder(args).Build().Run();

            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}