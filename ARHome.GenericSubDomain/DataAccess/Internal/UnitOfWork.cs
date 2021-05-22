using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ARHome.GenericSubDomain.DataAccess.Internal
{
    internal sealed class UnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        private readonly IEnumerable<IOnCommitHandler> _handlers;
        private readonly ILogger<UnitOfWork<TDbContext>> _logger;

        public UnitOfWork(TDbContext dbContext, IEnumerable<IOnCommitHandler> handlers, ILogger<UnitOfWork<TDbContext>> logger)
        {
            _dbContext = dbContext;
            _handlers = handlers;
            _logger = logger;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            if (!_dbContext.ChangeTracker.HasChanges())
                return 0;

            await BeforeCommit(cancellationToken);

            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task BeforeCommit(CancellationToken cancellationToken)
        {
            var orderedHandlers = _handlers.OrderBy(h => h.Order).ToArray();
            var entries = _dbContext.ChangeTracker.Entries().ToArray();

            foreach (var handler in orderedHandlers)
            {
                try
                {
                    await handler.BeforeCommit(entries, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Handle {handler.GetType()} with error.");

                    if (handler.IsRequired)
                    {
                        throw;
                    }
                }
            }
        }
    }
}