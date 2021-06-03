using System;
using Microsoft.Extensions.Logging;

namespace ARHome.GenericSubDomain.Extensions
{
    internal static class LoggerExtensions
    {
        private static readonly Action<ILogger, int, Exception> RetryErrorDefine = LoggerMessage.Define<int>(
            LogLevel.Error,
            new EventId(1, nameof(RetryError)),
            "Retry {retry}.");

        public static void RetryError(this ILogger logger, int retry, Exception exception)
        {
            RetryErrorDefine(logger, retry, exception);
        }
    }
}