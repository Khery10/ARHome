using ARHome.GenericSubDomain.RabbitMq.Internal;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.GenericSubDomain.RabbitMq
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMqPublisher(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection(nameof(RabbitMqOptions)).Get<RabbitMqOptions>();

            services.AddMassTransit(cfg =>
            {
                cfg.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(rabbit =>
                {
                    rabbit.Host(options.HostName, host =>
                    {
                        host.Username(options.UserName);
                        host.Password(options.Password);
                    });
                }));
            });
            services.AddScoped<IRabbitMqMessagePublisher, RabbitMqMessagePublisher>();

            return services;
        }
    }
}