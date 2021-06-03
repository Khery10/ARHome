using System;
using System.Reflection;
using ARHome.GenericSubDomain.Common.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ARHome.GenericSubDomain.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJsonSerializer(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddSingleton<IJsonSerializer, NewtonsoftJsonSerializer>();
            return services;
        }

        public static IServiceCollection AddCommon(this IServiceCollection services, Assembly[] assembliesForScan)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (assembliesForScan == null)
                throw new ArgumentNullException(nameof(assembliesForScan));

            services.TryAddScoped<IDateTimeProvider, DateTimeProvider>();
            services.TryAddSingleton<ITypesScanner>(new TypesScanner(assembliesForScan));
            services.AddJsonSerializer();

            return services;
        }
    }
}