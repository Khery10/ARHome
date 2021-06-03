using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ARHome.GenericSubDomain.Pipelines
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPipelines(this IServiceCollection services, Assembly[] assembliesForScan)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (assembliesForScan == null)
                throw new ArgumentNullException(nameof(assembliesForScan));

            services.AddMediatR(assembliesForScan);
            services.TryAddEnumerable(ServiceDescriptor.Scoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>)));

            var assemblyScanner = new AssemblyScanner(assembliesForScan.SelectMany(a => a.GetTypes()));

            assemblyScanner.ForEach(t =>
            {
                services.Add(ServiceDescriptor.Transient(t.InterfaceType, t.ValidatorType));
                services.Add(ServiceDescriptor.Transient(t.ValidatorType, t.ValidatorType));
            });

            return services;
        }
    }
}