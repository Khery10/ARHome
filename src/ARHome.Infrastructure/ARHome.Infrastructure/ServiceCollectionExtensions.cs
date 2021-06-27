using ARHome.DataAccess;
using ARHome.GenericSubDomain.RabbitMq;
using ARHome.Infrastructure.Abstractions.ImageStorage;
using ARHome.Infrastructure.Abstractions.Repositories;
using ARHome.Infrastructure.ImageStorage;
using ARHome.Infrastructure.Options;
using ARHome.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsStrings = configuration.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>();

            services
                .AddSingleton(connectionsStrings)
                .AddEntityFrameworkDataAccess<ARHomeContext>(connectionsStrings.ARHomeConnectionString)
                .AddRabbitMqPublisher(configuration)
                .AddRepositories()
                .AddImageStorage();

            return services;
        }
    }
}