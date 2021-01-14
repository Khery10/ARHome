namespace ARHome.Core.Configuration
{
    public class ARHomeSettings
    {
        public string ConnectionString { get; set; }

        public ARHomeDbContextSeed DbContextSeed { get; set; }
    }

    public class ARHomeDbContextSeed
    {
        public ARHomeCategory[] Categories { get; set; }
    }

    public class ARHomeCategory
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
