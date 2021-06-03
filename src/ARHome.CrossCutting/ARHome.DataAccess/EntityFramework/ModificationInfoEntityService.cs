using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ARHome.GenericSubDomain.Common;
using ARHome.Primitives;

namespace ARHome.DataAccess.EntityFramework
{
   internal sealed class ModificationInfoEntityService : IModificationInfoEntityService
   {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ModificationInfoEntityService(IDateTimeProvider dateTimeProvider) =>
            _dateTimeProvider = dateTimeProvider;

        public async Task SetModificationInfoAsync(
            IEntityObject[] entries,
            CancellationToken cancellationToken)
        {
            var targetEntries = entries
                .Where(e => e is IModificationInfoAccessor)
                .ToArray();

            if (!targetEntries.Any())
            {
                return;
            }

            var now = _dateTimeProvider.Now();

            foreach (var entry in targetEntries)
            {
                var entity = (IModificationInfoAccessor)entry;

                if (entry.Created == default)
                    entity.SetCreated(now);
                
                entity.SetModified(now);
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