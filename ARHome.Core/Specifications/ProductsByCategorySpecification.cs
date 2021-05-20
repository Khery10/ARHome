using System;
using System.Linq.Expressions;
using ARHome.Core.Entities;
using ARHome.Core.Specifications.Base;

namespace ARHome.Core.Specifications
{
    public class ProductsByCategorySpecification : BaseSpecification<Product>
    {
        public ProductsByCategorySpecification(int categoryId) 
            : base(p => p.CategoryId == categoryId)
        {
            AddInclude(p => p.Category);
        }
    }
}