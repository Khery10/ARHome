using System;

namespace ARHome.Client.Products.Queries.GetPagedProductsListByCategory
{
    public sealed class GetPagedProductsByCategoryQuery
    {
        public Guid CategoryId { get; set; }
        
        public int PageIndex { get; set; }
        
        public int PageSize { get; set; }
    }
}