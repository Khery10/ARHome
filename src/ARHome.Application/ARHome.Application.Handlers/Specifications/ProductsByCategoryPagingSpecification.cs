using System;
using System.Linq.Expressions;
using ARHome.Core.Categories;
using ARHome.Core.Products;
using ARHome.DataAccess.Specifications;

namespace ARHome.Application.Handlers.Specifications
{
    internal sealed class ProductsByCategoryPagingSpecification : BasePagingSpecification<Product>
    {
        public ProductsByCategoryPagingSpecification(CategoryKey categoryId, int pageIndex, int pageSize)
            : base(product => product.CategoryId == categoryId, pageIndex, pageSize)
        {
        }
    }
}