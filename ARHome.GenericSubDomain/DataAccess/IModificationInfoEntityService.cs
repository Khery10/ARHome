using System.Threading;
using System.Threading.Tasks;
using ARHome.Primitives;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ARHome.GenericSubDomain.DataAccess
{
    public interface IModificationInfoEntityService
    {
        Task SetModificationInfoAsync(EntityEntry[] entries, CancellationToken cancellationToken);

        Task SetModificationInfoAsync(IModificationInfoAccessor[] entities, CancellationToken cancellationToken);
    }
}