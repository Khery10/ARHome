using System.Threading;
using System.Threading.Tasks;
using ARHome.Primitives;

namespace ARHome.DataAccess
{
    public interface IOnCommitHandler
    {
        bool IsRequired { get; }

        int Order { get; }

        Task BeforeCommit(IEntityObject[] entries, CancellationToken cancellationToken);
    }
}