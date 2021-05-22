using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polly;

namespace ARHome.GenericSubDomain.Extensions
{
    public static class RetryExtensions
    {
        private static readonly TimeSpan DefaultRetryTimeout = TimeSpan.FromMilliseconds(200);
        private static readonly TimeSpan MaxRetryTimeout = TimeSpan.FromSeconds(10);

        public static async Task RetryAsync<TException>(
            this Func<CancellationToken, Task> func,
            ILogger logger,
            CancellationToken cancellationToken)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            var policy = Policy
                .Handle<TException>()
                .RetryForeverAsync((ex, retry) => logger.RetryError(retry, ex));

            await policy.ExecuteAsync(ct => func(ct), cancellationToken);
        }

        public static async Task RetryAsync<TException>(
            this Func<CancellationToken, Task> func,
            ILogger logger,
            int retryCount,
            CancellationToken cancellationToken)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (retryCount <= 0)
                throw new ArgumentException("RetryCount must be greater then 0.", nameof(retryCount));

            var policy = Policy
                .Handle<TException>()
                .RetryAsync(retryCount, (ex, retry) => logger.RetryError(retry, ex));

            await policy.ExecuteAsync(ct => func(ct), cancellationToken);
        }

        public static async Task<TResult> RetryAsync<TException, TResult>(
            this Func<CancellationToken, Task<TResult>> func,
            ILogger logger,
            int retryCount,
            CancellationToken cancellationToken)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (retryCount <= 0)
                throw new ArgumentException("RetryCount must be greater then 0.", nameof(retryCount));

            var policy = Policy
                .Handle<TException>()
                .RetryAsync(retryCount, (ex, retry) => logger.RetryError(retry, ex));

            return await policy.ExecuteAsync(ct => func(ct), cancellationToken);
        }

        public static async Task WaitAndRetryAsync<TException>(
            this Func<CancellationToken, Task> func,
            ILogger logger,
            CancellationToken cancellationToken)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            var policy = Policy
                .Handle<TException>()
                .WaitAndRetryForeverAsync(
                    CalculateTimeout,
                    (ex, retry, time) => logger.RetryError(retry, ex));

            await policy.ExecuteAsync(ct => func(ct), cancellationToken);
        }

        public static async Task WaitAndRetryAsync<TException>(
            this Func<CancellationToken, Task> func,
            ILogger logger,
            int retryCount,
            CancellationToken cancellationToken)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (retryCount <= 0)
                throw new ArgumentException("RetryCount must be greater then 0.", nameof(retryCount));

            var policy = Policy
                .Handle<TException>()
                .WaitAndRetryAsync(
                    retryCount,
                    CalculateTimeout,
                    (ex, time, retry, ctx) => logger.RetryError(retry, ex));

            await policy.ExecuteAsync(ct => func(ct), cancellationToken);
        }

        private static TimeSpan CalculateTimeout(int retry)
        {
            const int maxRetryCount = 50;

            var result = retry <= maxRetryCount
                ? DefaultRetryTimeout * retry
                : MaxRetryTimeout;

            return result;
        }
    }
}