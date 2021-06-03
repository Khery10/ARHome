using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace ARHome.GenericSubDomain.RabbitMq.Internal
{
    internal sealed class RabbitMqMessagePublisher : IRabbitMqMessagePublisher
    {
        private readonly IBusControl _bus;
        private readonly ILogger<RabbitMqMessagePublisher> _logger;

        public RabbitMqMessagePublisher(IBusControl bus, ILogger<RabbitMqMessagePublisher> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task TryPublishAsync<T>(T message, CancellationToken cancellationToken)
            where T : class
        {
            try
            {
                await _bus.Publish(message, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(RabbitMqMessagePublisher)}. Rabbit publish with exception.");
            }
        }
    }
}