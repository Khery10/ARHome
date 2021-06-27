using System;
using ARHome.Primitives;

namespace ARHome.Core.Categories
{
    public sealed class Category : EntityObject<Category, CategoryKey>
    {
        internal Category(
            string name, 
            string description)
        {
            Id = new CategoryKey(Guid.NewGuid());
            Name = name;
            Description = description;
        }
        
        public CategoryKey Id { get; private set; }

        public string Name { get; private set; }
        
        public string Description { get; private set; }
        
        public override CategoryKey GetKey() => Id;
    }
}