using ARHome.Infrastructure.Abstractions.ImageStorage;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.Infrastructure.ImageStorage
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddImageStorage(this IServiceCollection services)
        {
            services
                .AddSingleton<IImageStorage, DirectoryImageStorage>()
                .AddHttpClient<DirectoryImageStorage>();

            return services;
        }
    }
}