using System;

namespace ARHome.GenericSubDomain.Common.Internal
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now(TimeSpan? offset = null)
        {
            return new DateTimeOffset(DateTime.UtcNow, offset ?? TimeSpan.Zero);
        }
    }
}