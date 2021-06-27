using System.Linq;
using System.Reflection;
using ARHome.Application;
using ARHome.Application.Handlers;
using ARHome.GenericSubDomain.Common;
using ARHome.GenericSubDomain.Middleware;
using ARHome.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ARHome.Api
{
    public class Startup
    {
        private static readonly string[] AssembliesForScan =
        {
            "ARHome.Application.Handlers",
            "ARHome.Application.Segmentation",
            "ARHome.Application.Validation",
            "ARHome.Core"
        };

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var assembliesForScan = AssembliesForScan.Select(Assembly.Load).ToArray();

            services
                .AddApplication(_configuration, assembliesForScan)
                .AddInfrastructure(_configuration)
                .AddCommon(assembliesForScan)
                .AddSingleton(_configuration)
                .AddExceptionDescriptors()
                .AddMvc()
                .AddNewtonsoftJson(SetJsonConfiguration);
        }

        public void Configure(IApplicationBuilder app, IConfiguration configuration)
        {
            app
                .UseRouting()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); })
                .UseAutoMigrate(configuration);
        }

        private static void SetJsonConfiguration(MvcNewtonsoftJsonOptions options)
        {
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}