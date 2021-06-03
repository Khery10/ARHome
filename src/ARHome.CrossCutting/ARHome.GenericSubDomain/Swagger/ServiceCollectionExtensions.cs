using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ARHome.GenericSubDomain.Swagger
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            AssemblyName assemblyName = Assembly.GetEntryAssembly().GetName();
            const string version = "v1";

            var apiInfo = new OpenApiInfo
            {
                Title = assemblyName.Name,
                Version = version
            };

            services
                .AddSingleton(apiInfo)
                .AddSwaggerGen(s => {
                    s.CustomSchemaIds(t => t.FullName);
                    s.SwaggerDoc(version, apiInfo);
                    s.AddXmlDocs(AppConsts.AppNamespacePrefix);
                })
                .AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        private static void AddXmlDocs(this SwaggerGenOptions options, string assemblyPrefix)
        {
            var assemblyNames = AppDomain.CurrentDomain
                .GetAssemblies()
                .Select(a => a.GetName().Name)
                .Where(n => n.StartsWith(assemblyPrefix))
                .ToArray();

            foreach (var assemblyName in assemblyNames)
            {
                var xmlDocsPath = Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.xml");

                if (File.Exists(xmlDocsPath))
                {
                    options.IncludeXmlComments(xmlDocsPath);
                }
            }
        }
    }
}