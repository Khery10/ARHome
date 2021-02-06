using ARHome.Application.Models;
using ARHome.Core.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARHome.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoryList();

        Task<IPagedList<CategoryModel>> SearchCategories(PageSearchArgs args);

        Task<CategoryModel> GetCategoryById(int Id);
    }
}
