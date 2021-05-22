using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ARHome.GenericSubDomain.Background
{
    public static class ServiceCollectionExtensions
    {

        public static bool TryAddPollingServices<TService, TOptions>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TService : PollingService
            where TOptions : class, IPollingServiceOptions
        {
            var result = false;
            var serviceOptionsSection = configuration.GetSection(typeof(TOptions).Name);
            var serviceOptions = serviceOptionsSection?.Get<TOptions>();
            if (serviceOptions is { } && serviceOptions.MaxThreadCount > 0)
            {
                services.Configure<TOptions>(serviceOptionsSection);
                for (var count = 0; count < serviceOptions.MaxThreadCount; count++)
                    services.AddSingleton<IHostedService, TService>();

                result = true;
            }

            return result;
        }
    }
}