using ARHome.GenericSubDomain.Middleware.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.GenericSubDomain.Middleware
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExceptionDescriptors(this IServiceCollection services)
        {
            services
                .AddSingleton<IExceptionDescriptor, ValidationExceptionDescriptor>()
                .AddSingleton<IExceptionDescriptor, ARHomeInvalidOperationDescriptor>();

            return services;
        }
    }
}