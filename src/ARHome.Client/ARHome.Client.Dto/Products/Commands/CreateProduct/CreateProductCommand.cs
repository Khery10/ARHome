using System;

namespace ARHome.Client.Products.Commands.CreateProduct
{
    public sealed class CreateProductCommand
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }
        
        public Guid CategoryId { get; set; }
    }
}