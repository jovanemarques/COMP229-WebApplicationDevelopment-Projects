using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ConfiguringApps
{
    public class Program
    {

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseDefaultServiceProvider((context, options) => {
                    options.ValidateScopes =
                        context.HostingEnvironment.IsDevelopment();
                })
                .UseStartup<Startup>()
                .Build();
        }
    }
}
