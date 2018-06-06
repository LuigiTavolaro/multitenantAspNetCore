using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MultiTenant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
             .UseKestrel()
             .UseContentRoot(Directory.GetCurrentDirectory())
             .UseUrls("http://localhost:6001", "http://localhost:6002")
             .UseIISIntegration()
             .UseStartup<Startup>()
             .Build();

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
