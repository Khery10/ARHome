using System;

namespace ARHome.GenericSubDomain.Common
{
    public interface IDateTimeProvider
    {
        DateTimeOffset Now(TimeSpan? offset = null);
    }
}