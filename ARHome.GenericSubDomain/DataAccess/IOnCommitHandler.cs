using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ARHome.GenericSubDomain.DataAccess
{
    public interface IOnCommitHandler
    {
        bool IsRequired { get; }

        int Order { get; }

        Task BeforeCommit(EntityEntry[] entries, CancellationToken cancellationToken);
    }
}