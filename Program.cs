using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration; // OpenShift Line 1
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ConfigService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            var config = new ConfigurationBuilder().AddEnvironmentVariables("").Build(); //OpenShift 2nd line added
            var url = config["ASPNETCORE_URLS"] ?? "http://*:8080"; //OpenShift 3rd line added

            var host = new WebHostBuilder()
             .UseKestrel()
             .UseContentRoot(Directory.GetCurrentDirectory())
             .UseIISIntegration()
            // .UseStartup()
             .UseUrls(url) //OpenShift 4th line added
             .Build();

             host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
