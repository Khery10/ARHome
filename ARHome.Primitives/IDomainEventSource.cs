using System.Collections.Generic;

namespace ARHome.Primitives
{
    public interface IDomainEventSource
    {
        IReadOnlyCollection<DomainEvent> DomainEvents { get; }
    }
}