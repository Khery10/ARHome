using System;

namespace ARHome.Primitives
{
    public interface IModificationInfoAccessor
    {
        void SetCreated(DateTimeOffset now);
        void SetModified(DateTimeOffset now);
    }
}