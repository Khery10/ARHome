using ARHome.Core.Products;
using ARHome.DataAccess.Specifications;

namespace ARHome.Application.Handlers.Specifications
{
    internal sealed class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(string productName)
            : base(p => p.Name.Contains(productName))
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification(ProductKey productId)
            : base(p => p.Id == productId)
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification()
            : base(null)
        {
            AddInclude(p => p.Category);
        }
    }
}
