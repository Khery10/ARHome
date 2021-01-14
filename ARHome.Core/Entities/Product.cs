using ARHome.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARHome.Core.Entities
{
    public class Product : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
 
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public static Product Create(int productId, int categoryId, string name)
        {
            var product = new Product
            {
                Id = productId,
                CategoryId = categoryId,
                Name = name
            };
            return product;
        }
    }
}
