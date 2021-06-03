using System;
using Microsoft.Extensions.Logging;

namespace ARHome.GenericSubDomain.Background
{
    internal static class LoggerExtensions
    {
        private static readonly Action<ILogger, Exception> PollingFailed = LoggerMessage.Define(
            LogLevel.Error,
            new EventId(1, nameof(PollFailed)),
            "A poll operation failed.");

        public static void PollFailed(this ILogger logger, Exception exception)
        {
            PollingFailed(logger, exception);
        }
    }
}