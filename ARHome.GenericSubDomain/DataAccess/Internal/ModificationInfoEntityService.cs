using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ARHome.GenericSubDomain.Common;
using ARHome.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ARHome.GenericSubDomain.DataAccess.Internal
{
   internal sealed class ModificationInfoEntityService : IModificationInfoEntityService
   {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ModificationInfoEntityService(IDateTimeProvider dateTimeProvider) =>
            _dateTimeProvider = dateTimeProvider;

        public async Task SetModificationInfoAsync(
            EntityEntry[] entries,
            CancellationToken cancellationToken)
        {
            var targetEntries = entries
                .Where(e => e.Entity is IModificationInfoAccessor)
                .ToArray();

            if (!targetEntries.Any())
            {
                return;
            }

            var now = _dateTimeProvider.Now();

            foreach (var entry in targetEntries)
            {
                var entity = (IModificationInfoAccessor)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.SetCreated(now);
                        break;

                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entity.SetModified(now);
                        break;
                }
            }
        }

        public async Task SetModificationInfoAsync(
            IModificationInfoAccessor[] entities,
            CancellationToken cancellationToken)
        {
            var now = _dateTimeProvider.Now();

            foreach (var entity in entities)
            {
                entity.SetCreated(now);
                entity.SetModified(now);
            }
        }
    }
}