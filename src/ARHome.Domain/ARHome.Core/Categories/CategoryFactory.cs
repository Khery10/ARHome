using System;
using System.Threading.Tasks;

namespace ARHome.Core.Categories
{
    public sealed class CategoryFactory
    {
        public Category Create(
            string name,
            string description,
            SurfaceType surfaceType)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            
            return new Category(name, description, surfaceType);
        }
    }
}