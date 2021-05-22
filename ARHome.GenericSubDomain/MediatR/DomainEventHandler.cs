using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ARHome.GenericSubDomain.MediatR
{
    public abstract class DomainEventHandler<TDomainEvent> : INotificationHandler<DomainEventWrapper<TDomainEvent>>
    {
        public Task Handle(DomainEventWrapper<TDomainEvent> notification, CancellationToken cancellationToken)
        {
            return Handle(notification.DomainEvent, cancellationToken);
        }

        protected abstract Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken);
    }
}