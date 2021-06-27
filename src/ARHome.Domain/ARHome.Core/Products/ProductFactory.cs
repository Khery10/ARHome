using System;
using ARHome.Core.Categories;

namespace ARHome.Core.Products
{
    public sealed class ProductFactory
    {
        public Product Create(
            string name,
            string description,
            CategoryKey categoryId)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (categoryId is null)
                throw new ArgumentNullException(nameof(categoryId));

            return new Product(name, description, categoryId);
        }
    }
}