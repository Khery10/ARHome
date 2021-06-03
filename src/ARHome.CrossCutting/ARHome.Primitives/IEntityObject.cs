using System;

namespace ARHome.Primitives
{
    public interface IEntityObject<out TKey> : IEntityObject
    {
        TKey GetKey();
        
    }
    
    
    public interface IEntityObject
    {
        object GetKey();

        DateTimeOffset Created { get; }
        
        DateTimeOffset Modified { get; }
    }
}