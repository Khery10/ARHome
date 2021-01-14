using ARHome.Core.Entities.Base;
using ARHome.Core.Repositories.Base;
using ARHome.Infrastructure.Data;

namespace ARHome.Infrastructure.Repository.Base
{
    public class Repository<T> : RepositoryBase<T, int>, IRepository<T>
        where T : class, IEntityBase<int>
    {
        public Repository(ARHomeContext context)
            : base(context)
        {
        }
    }
}
