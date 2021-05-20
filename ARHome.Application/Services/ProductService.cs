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
using ARHome.Core.Specifications;
using ARHome.Infrastructure.Paging;

namespace ARHome.Application.Services
{
    public class ProductService : ServiceBase<Product, ProductModel>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IAppLogger<ProductService> logger)
            : base(productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductModel>> GetProductList()
            => await GetListAsync();

        public async Task<IPagedList<ProductModel>> SearchProducts(PageSearchArgs args)
        {
            var productPagedList = await _productRepository.SearchProductsAsync(args);

            //TODO: PagedList<TSource> will be mapped to PagedList<TDestination>;
            var productModels = ObjectMapper.Mapper.Map<List<ProductModel>>(productPagedList.Items);

            var productModelPagedList = new PagedList<ProductModel>(
                productPagedList.PageIndex,
                productPagedList.PageSize,
                productPagedList.TotalCount,
                productPagedList.TotalPages,
                productModels);

            return productModelPagedList;
        }

        public async Task<ProductModel> GetProductById(int productId)
            => await GetByIdAsync(productId);

        public async Task<IEnumerable<ProductModel>> GetProductsByName(string name)
        {
            var spec = new ProductWithCategorySpecification(name);
            var productList = await _productRepository.GetAsync(spec);

            var productModels = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);

            return productModels;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByCategoryId(int categoryId)
        {
            var spec = new ProductsByCategorySpecification(categoryId);
            var productList = await _productRepository.GetAsync(spec);

            var productModels = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);

            return productModels;
        }

        public async Task<ProductModel> CreateProduct(ProductModel product) 
            => await CreateAsync(product);

        public async Task UpdateProduct(ProductModel product) 
            => await UpdateAsync(product);

        public async Task DeleteProductById(int productId) 
            => await DeleteByIdAsync(productId);
    }
}
