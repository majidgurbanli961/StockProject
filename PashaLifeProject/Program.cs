using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace PashaLifeProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogger();
            try
            {
                CreateHostBuilder(args).Build().Run();

            }
            finally 
            {

                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                
                .ConfigureWebHostDefaults(webBuilder => 
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                    
                });
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("log.txt").CreateLogger();
        }
    }
}
