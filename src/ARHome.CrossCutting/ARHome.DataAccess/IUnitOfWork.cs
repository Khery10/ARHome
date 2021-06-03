using System.Threading;
using System.Threading.Tasks;

namespace ARHome.DataAccess
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}