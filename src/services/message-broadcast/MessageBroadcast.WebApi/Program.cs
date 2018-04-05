using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

#pragma warning disable 1591

namespace MessageBroadcast.WebApi
{
    public class Program
    {
        public static void Main(string[] args) {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) {
            var theWebHostBuilder = WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>();

            theWebHostBuilder
                .UseUrls("http://0.0.0.0:5001");

            return theWebHostBuilder.Build();
        }
    }
}
