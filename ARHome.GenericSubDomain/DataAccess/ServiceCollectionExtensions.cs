using System;
using ARHome.GenericSubDomain.DataAccess.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.GenericSubDomain.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess<TDbContext>(
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
                .AddScoped<IDbContextAccessor, DbContextAccessor<TDbContext>>()
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