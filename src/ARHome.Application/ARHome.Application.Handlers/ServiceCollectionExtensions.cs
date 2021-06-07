using ARHome.Application.Handlers.Converters;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace ARHome.Application.Handlers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(AutomapperProfiler).Assembly)
                .AddScoped<CategoryConverter>()
                .AddScoped<ProductConverter>();
            
            return services;
        }
    }
}