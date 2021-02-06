using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ARHome.Application.Interfaces;
using ARHome.Application.Interfaces.Base;
using ARHome.Application.Mapper;
using ARHome.Application.Models;
using ARHome.Core.Entities;
using ARHome.Core.Interfaces;
using ARHome.Core.Paging;
using ARHome.Core.Repositories;
using ARHome.Core.Repositories.Base;
using ARHome.Infrastructure.Paging;

namespace ARHome.Application.Services
{
    public class CategoryService : ServiceBase<Category, CategoryModel>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, IAppLogger<CategoryService> logger)
            : base(categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
            => await GetListAsync();

        public async Task UpdateCategory(CategoryModel categoryModel)
            => await UpdateAsync(categoryModel);

        public async Task<IPagedList<CategoryModel>> SearchCategories(PageSearchArgs args)
        {
            var categoryPagedList = await _categoryRepository.SearchCategoriesAsync(args);

            var categoryModels = ObjectMapper.Mapper.Map<List<CategoryModel>>(categoryPagedList.Items);

            var categoryModelPagedList = new PagedList<CategoryModel>(
                categoryPagedList.PageIndex,
                categoryPagedList.PageSize,
                categoryPagedList.TotalCount,
                categoryPagedList.TotalPages,
                categoryModels);

            return categoryModelPagedList;
        }

        public async Task<CategoryModel> GetCategoryById(int id) 
            => await GetByIdAsync(id);
    }
}
