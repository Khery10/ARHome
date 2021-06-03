using System;
using ARHome.DataAccess.EntityFramework;
using ARHome.DataAccess.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkDataAccess<TDbContext>(
            this IServiceCollection services,
            string connectionString)
            where TDbContext : DbContext
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("String IsNullOrWhiteSpace.", nameof(connectionString));

            services
                .AddDbContextPool<TDbContext>(options => options.UseNpgsql(connectionString))
                .AddScoped<IUnitOfWork, UnitOfWork<TDbContext>>()
                .AddScoped<IModificationInfoEntityService, ModificationInfoEntityService>()
                .AddSingleton<ISpecificationEvaluator, SpecificationEvaluator>()
                .AddOnCommitHandler<ModificationInfoSetter>();

            return services;
        }

        public static IServiceCollection AddOnCommitHandler<THandler>(this IServiceCollection services)
            where THandler : class, IOnCommitHandler
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IOnCommitHandler, THandler>();

            return services;
        }
    }
}