using ARHome.Application.Models.Base;
using System;

namespace ARHome.Application.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
