using ARHome.Core.Categories;
using ARHome.Core.Products;
using ARHome.DataAccess.Specifications;

namespace ARHome.Application.Handlers.Specifications
{
    internal sealed class ProductsByCategorySpecification : BaseSpecification<Product>
    {
        public ProductsByCategorySpecification(CategoryKey categoryId) 
            : base(p => p.CategoryId == categoryId)
        {
        }
    }
}