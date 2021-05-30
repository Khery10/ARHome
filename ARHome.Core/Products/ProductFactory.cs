using System;
using ARHome.Core.Categories;

namespace ARHome.Core.Products
{
    public sealed class ProductFactory
    {
        public Product Create(
            string name,
            string description,
            string imageUrl,
            CategoryKey categoryId)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(imageUrl))
                throw new ArgumentNullException(nameof(imageUrl));

            if (categoryId is null)
                throw new ArgumentNullException(nameof(categoryId));

            return new Product(name, description, imageUrl, categoryId);
        }
    }
}