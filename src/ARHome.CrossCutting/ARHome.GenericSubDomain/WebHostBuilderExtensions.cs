using ARHome.GenericSubDomain.Logger;
using ARHome.GenericSubDomain.Middleware;
using ARHome.GenericSubDomain.Swagger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace ARHome.GenericSubDomain
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UseGenericSubDomain(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSwagger();
                services.TryAddEnumerable(ServiceDescriptor.Transient<IStartupFilter, SwaggerStartupFilter>());
                services.TryAddEnumerable(ServiceDescriptor.Transient<IStartupFilter, ExceptionHandlerStartupFilter>());
                services.TryAddEnumerable(ServiceDescriptor.Transient<IStartupFilter, SerilogStartupFilter>());
                services.TryAddEnumerable(ServiceDescriptor.Transient<IStartupFilter, RequestHandlerStartupFilter>());
            });

            return webHostBuilder;
        }
    }
}