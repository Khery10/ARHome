using System.Collections.Generic;

namespace ARHome.Primitives
{
    public abstract class AggregateRoot<T, TKey> : EntityObject<T, TKey>, IDomainEventSource
        where T : EntityObject<T, TKey>
    {
        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

        IReadOnlyCollection<DomainEvent> IDomainEventSource.DomainEvents => _domainEvents;

        protected void AddDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
            where TDomainEvent : DomainEvent
        {
            _domainEvents.Add(domainEvent);
        }
    }
}