using System;
using System.Collections;
using System.Collections.Generic;

namespace ARHome.Primitives
{
    public abstract class EntityObject<T, TKey> : 
        IEntityObject<TKey>, 
        IEntityObject, 
        IEquatable<T>, 
        IModificationInfoAccessor
        where T : EntityObject<T, TKey>
    {
        public abstract TKey GetKey();

        object IEntityObject.GetKey() => GetKey();

        public bool Equals(T other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return ReferenceEquals(this, other) || GetKey().Equals(other.GetKey());
        }

        public override bool Equals(object obj)
        {
            return obj is T other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(0, GetKey());
        }

        public DateTimeOffset Created { get; private set; }
        public DateTimeOffset Modified { get; private set; }

        void IModificationInfoAccessor.SetCreated(DateTimeOffset now)
        {
            Created = now;
            Modified = now;
        }

        void IModificationInfoAccessor.SetModified(DateTimeOffset now)
        {
            Modified = now;
        }
    }
}