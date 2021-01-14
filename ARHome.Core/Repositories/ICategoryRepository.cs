using ARHome.Core.Entities;
using ARHome.Core.Paging;
using ARHome.Core.Repositories.Base;
using System.Threading.Tasks;

namespace ARHome.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IPagedList<Category>> SearchCategoriesAsync(PageSearchArgs args);
    }
}
