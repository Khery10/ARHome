using MediatR;

namespace ARHome.GenericSubDomain.MediatR
{
    public sealed class DomainEventWrapper<TDomainEvent> : INotification
    {
        public TDomainEvent DomainEvent { get; }

        internal DomainEventWrapper(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }

    public static class DomainEventWrapper
    {
        public static DomainEventWrapper<TDomainEvent> Create<TDomainEvent>(TDomainEvent domainEvent)
        {
            return new DomainEventWrapper<TDomainEvent>(domainEvent);
        }
    }
}