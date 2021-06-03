using System.Threading;
using System.Threading.Tasks;

namespace ARHome.GenericSubDomain.RabbitMq
{
    public interface IRabbitMqMessagePublisher
    {
        Task TryPublishAsync<T>(T message, CancellationToken cancellationToken) where T : class;
    }
}