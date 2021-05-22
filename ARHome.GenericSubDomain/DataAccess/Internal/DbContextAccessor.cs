using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ARHome.GenericSubDomain.DataAccess.Internal
{
    internal sealed class DbContextAccessor<TDbContext> : IDbContextAccessor
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public DbContextAccessor(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class => _dbContext.Entry(entity);

        public DbSet<TEntity> Set<TEntity>() where TEntity : class => _dbContext.Set<TEntity>();
    }
}