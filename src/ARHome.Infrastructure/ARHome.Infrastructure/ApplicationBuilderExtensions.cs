using ARHome.Infrastructure.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAutoMigrate(this IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            var deployOptions = configuration.GetSection(nameof(DeployOptions))?.Get<DeployOptions>();
            
            if (deployOptions?.UseAutoMigrate ?? false)
            {
                using var scope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                scope.ServiceProvider.GetService<ARHomeContext>()?.Database.Migrate();
            }

            return applicationBuilder;
        }
    }
}