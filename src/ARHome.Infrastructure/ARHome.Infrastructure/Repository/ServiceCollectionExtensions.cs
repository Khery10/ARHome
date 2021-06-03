using ARHome.Infrastructure.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.Infrastructure.Repository
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IProductRepository, ProductRepository>();
            
            return services;
        }
    }
}