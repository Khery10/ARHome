using System;
using ARHome.Primitives;

namespace ARHome.Core.Categories
{
    public sealed class CategoryKey : SimpleKey<CategoryKey>
    {
        public CategoryKey(Guid value) : base(value)
        {
        }
    }
}