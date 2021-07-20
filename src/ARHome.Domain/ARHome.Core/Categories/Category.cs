using System;
using ARHome.Primitives;

namespace ARHome.Core.Categories
{
    public sealed class Category : EntityObject<Category, CategoryKey>
    {
        internal Category(
            string name, 
            string description,
            SurfaceType surfaceType)
        {
            Id = new CategoryKey(Guid.NewGuid());
            Name = name;
            Description = description;
            SurfaceType = surfaceType;
        }
        
        public CategoryKey Id { get; private set; }

        public string Name { get; private set; }
        
        public string Description { get;  set; }

        public SurfaceType SurfaceType { get; set; }
        
        public override CategoryKey GetKey() => Id;
    }
}