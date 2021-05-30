using System;
using System.Threading.Tasks;

namespace ARHome.Core.Categories
{
    public sealed class CategoryFactory
    {
        public Category Create(
            string name,
            string description,
            string imageUrl)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(imageUrl))
                throw new ArgumentNullException(nameof(imageUrl));

            return new Category(name, description, imageUrl);
        }
    }
}