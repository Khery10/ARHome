using System.Reflection;
using ARHome.Application.Handlers;
using ARHome.Core.Categories;
using ARHome.Core.Products;
using ARHome.GenericSubDomain.Pipelines;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] assembliesForScan)
        {
            services
                .AddPipelines(assembliesForScan)
                .AddHandlers()
                .AddScoped<CategoryFactory>()
                .AddScoped<ProductFactory>();

            return services;
        }
    }
}