using System;
using ARHome.Primitives;

namespace ARHome.Core.Categories
{
    public sealed class Category : EntityObject<Category, CategoryKey>
    {
        private Category() { }
        
        internal Category(
            string name, 
            string description, 
            string imageUrl)
        {
            Id = new CategoryKey(Guid.NewGuid());
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
        
        public CategoryKey Id { get; private set; }

        public string Name { get; private set; }
        
        public string Description { get; private set; }
        
        public string ImageUrl { get; set; }

        public override CategoryKey GetKey() => Id;
    }
}