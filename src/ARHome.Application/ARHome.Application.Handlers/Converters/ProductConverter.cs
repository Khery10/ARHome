using System.Collections.Generic;
using System.Linq;
using ARHome.Client.Products;
using ARHome.Core.Products;

namespace ARHome.Application.Handlers.Converters
{
    internal sealed class ProductConverter
    {
        public static ProductDto ConvertToDto(Product product)
        {
            return new()
            {
                Id = product.Id.Value,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId.Value,
                ImageUrl = product.ImageUrl,
                Category = product.Category is {} ? CategoryConverter.ConvertToDto(product.Category) : null
            };
        }

        public static ProductDto[] ConvertToDto(IEnumerable<Product> products) 
            => products.Select(ConvertToDto).ToArray();
    }
}