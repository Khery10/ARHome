using ARHome.Core.Entities.Base;
using ARHome.Core.Repositories.Base;
using ARHome.Infrastructure.Data;

namespace ARHome.Infrastructure.Repository.Base
{
    public class EnumRepository<T> : RepositoryBase<T, int>, IEnumRepository<T>
        where T : class, IEntityBase<int>
    {
        public EnumRepository(ARHomeContext context)
            : base(context)
        {
        }
    }
}
