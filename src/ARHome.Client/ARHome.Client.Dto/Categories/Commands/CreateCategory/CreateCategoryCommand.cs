namespace ARHome.Client.Categories.Commands.CreateCategory
{
    public sealed class CreateCategoryCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string SurfaceType { get; set; }
        public string ImageUrl { get; set; }
    }
}