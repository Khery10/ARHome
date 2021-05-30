using System;
using ARHome.Primitives;

namespace ARHome.Core.Products
{
    public sealed class ProductKey : SimpleKey<ProductKey>
    {
        public ProductKey(Guid value) : base(value)
        {
        }
    }
}