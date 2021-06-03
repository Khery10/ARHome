using System.Threading;
using System.Threading.Tasks;
using ARHome.Primitives;

namespace ARHome.DataAccess.EntityFramework
{
    internal sealed class ModificationInfoSetter : IOnCommitHandler
    {
        private readonly IModificationInfoEntityService _modificationInfoEntityService;

        public ModificationInfoSetter(IModificationInfoEntityService modificationInfoEntityService)
        {
            _modificationInfoEntityService = modificationInfoEntityService;
        }

        public bool IsRequired  => true;

        public int Order =>  int.MinValue;

        public async Task BeforeCommit(IEntityObject[] entries, CancellationToken cancellationToken)
        {
            await _modificationInfoEntityService.SetModificationInfoAsync(entries, cancellationToken);
        }
    }
}