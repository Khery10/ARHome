using ARHome.Application.Models;
using ARHome.Core.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARHome.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<IPagedList<ProductModel>> SearchProducts(PageSearchArgs args);
        Task<ProductModel> GetProductById(int productId);
        Task<IEnumerable<ProductModel>> GetProductsByName(string name);
        Task<IEnumerable<ProductModel>> GetProductsByCategoryId(int categoryId);
        Task<ProductModel> CreateProduct(ProductModel product);
        Task UpdateProduct(ProductModel product);
        Task DeleteProductById(int productId);
    }
}
