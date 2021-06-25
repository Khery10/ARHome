using System.Reflection;
using ARHome.Application.Handlers;
using ARHome.Application.Segmentation;
using ARHome.Core.Categories;
using ARHome.Core.Products;
using ARHome.GenericSubDomain.Pipelines;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services, 
            IConfiguration configuration,
            Assembly[] assembliesForScan)
        {
            services
                .AddPipelines(assembliesForScan)
                .AddHandlers()
                .AddSegmentation(configuration)
                .AddScoped<CategoryFactory>()
                .AddScoped<ProductFactory>();

            return services;
        }
    }
}