using ARHome.Application.Models.Base;

namespace ARHome.Application.Models
{
    public class CategoryModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
