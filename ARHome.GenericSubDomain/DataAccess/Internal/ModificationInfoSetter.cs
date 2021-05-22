using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ARHome.GenericSubDomain.DataAccess.Internal
{
    internal sealed class ModificationInfoSetter : IOnCommitHandler
    {
        private readonly IModificationInfoEntityService _modificationInfoEntityService;

        public ModificationInfoSetter(IModificationInfoEntityService modificationInfoEntityService)
        {
            _modificationInfoEntityService = modificationInfoEntityService;
        }

        public bool IsRequired { get; } = true;

        public int Order { get; } = int.MinValue;

        public async Task BeforeCommit(EntityEntry[] entries, CancellationToken cancellationToken)
        {
            await _modificationInfoEntityService.SetModificationInfoAsync(entries, cancellationToken);
        }
    }
}