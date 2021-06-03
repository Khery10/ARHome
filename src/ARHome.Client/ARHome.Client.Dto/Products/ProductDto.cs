using System;
using ARHome.Client.Categories;

namespace ARHome.Client.Products
{
    public sealed class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string ImageUrl { get; set; }

        public Guid CategoryId { get; set; }

        public CategoryDto Category { get; set; }
    }
}