using System;

namespace ARHome.Client.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string SurfaceType { get; set; }
    }
}