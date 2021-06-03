using System.Threading;
using System.Threading.Tasks;
using ARHome.Primitives;

namespace ARHome.DataAccess
{
    public interface IModificationInfoEntityService
    {
        Task SetModificationInfoAsync(IEntityObject[] entries, CancellationToken cancellationToken);

        Task SetModificationInfoAsync(IModificationInfoAccessor[] entities, CancellationToken cancellationToken);
    }
}