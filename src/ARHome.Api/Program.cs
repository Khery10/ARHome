
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ARHome.GenericSubDomain;

namespace ARHome.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseGenericSubDomain();

            return host;
        }
    }
}