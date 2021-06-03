using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ARHome.GenericSubDomain.Background
{
     public abstract class PollingService : BackgroundService
    {
        private readonly IOptionsMonitor<IPollingServiceOptions> _options;
        protected ILogger Logger { get; }

        private readonly TimeSpan _minInterval = TimeSpan.Zero;

        protected PollingService(IOptionsMonitor<IPollingServiceOptions> options, ILogger logger)
        {
            _options = options;
            Logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Factory.StartNew(
                () => ExecuteCoreAsync(stoppingToken),
                stoppingToken,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Current);
        }

        private async Task ExecuteCoreAsync(CancellationToken stoppingToken)
        {
            TimeSpan interval = _minInterval;

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    PollingServiceLoad serviceLoad = await PollAsync(stoppingToken);
                    interval = UpdateInterval(serviceLoad, interval);
                }
                catch (Exception e)
                {
                    Logger.PollFailed(e);
                }

                if (interval > _minInterval)
                {
                    await Task.Delay(interval, stoppingToken);
                }
            }
        }

        protected abstract Task<PollingServiceLoad> PollAsync(CancellationToken stoppingToken);

        private TimeSpan UpdateInterval(PollingServiceLoad currentLoad, TimeSpan currentInterval)
        {
            switch (currentLoad)
            {
                case PollingServiceLoad.High:
                    return _minInterval;

                case PollingServiceLoad.Medium:
                    return currentInterval;

                case PollingServiceLoad.Low:
                    IPollingServiceOptions options = _options.CurrentValue;
                    TimeSpan interval = currentInterval + options.PollingIntervalFade;

                    if (interval > options.MaxPollingInterval)
                    {
                        interval = options.MaxPollingInterval;
                    }

                    return interval;

                default:
                    throw new ArgumentOutOfRangeException(nameof(currentLoad));
            }
        }
    }
}