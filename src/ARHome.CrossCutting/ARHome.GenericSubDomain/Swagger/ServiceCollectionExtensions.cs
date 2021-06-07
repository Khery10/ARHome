using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.GenericSubDomain.Swagger
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            AssemblyName assemblyName = Assembly.GetEntryAssembly().GetName();
            const string version = "v1";

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = version;
                    document.Info.Title = $"{assemblyName.Name} HTTP API";
                    document.Info.Description = "The ARHome Service HTTP API";
                    document.Info.TermsOfService = "Terms Of Service";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = assemblyName.Name,
                        Email = string.Empty,
                        Url = string.Empty
                    };
                    
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });

            return services;
        }
    }
}