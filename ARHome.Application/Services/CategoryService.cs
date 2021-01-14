using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ARHome.Application.Interfaces;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, IAppLogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            var categoryList = await _categoryRepository.ListAllAsync();

            var categoryModels = ObjectMapper.Mapper.Map<IEnumerable<CategoryModel>>(categoryList);

            return categoryModels;
        }

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
    }
}
