using System;
using ARHome.Core.Categories;
using ARHome.Primitives;

namespace ARHome.Core.Products
{
    public sealed class Product : EntityObject<Product, ProductKey>
    {
        internal Product(
            string name,
            string description,
            CategoryKey categoryId)
        {
            Id = new ProductKey(Guid.NewGuid());
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
        
        public ProductKey Id { get; private set; }
        
        public string Name { get; private set; }
        
        public string Description { get; private set; }

        public CategoryKey CategoryId { get; private set; }
        
        public Category Category { get; private set; }

        public override ProductKey GetKey() => Id;
    }
}