using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SampleSignalR
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                                //.SetBasePath(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName)
                                //.AddJsonFile("appsettings.json", false)
                                .Build();
            return WebHost.CreateDefaultBuilder(args).
              //UseUrls(config["Urls:HostingUrl"]).
              UseStartup<Startup>();
        }
    }
}
