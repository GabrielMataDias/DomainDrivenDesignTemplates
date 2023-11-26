using System.Collections.ObjectModel;

namespace Core.Domain.Abstracts;
/// <summary>
/// Represents the base class for aggregate roots in the domain.
/// Aggregate roots serve as the entry point to an aggregate, a cluster of domain objects that can be treated as a single unit.
/// </summary>
internal abstract class AggregateRoot : Entity
{
    /// <summary>
    /// Ccollection of domain events associated with this aggregate root.
    /// </summary>
    public IList<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

    /// <summary>
    /// Adds a domain event to the list of associated domain events.
    /// </summary>
    /// <param name="domainEvent">The domain event to add.</param>
    public void AddDomainEvent(DomainEvent domainEvent) => DomainEvents.Add(domainEvent);

    /// <summary>
    /// Removes a domain event from the list of associated domain events.
    /// </summary>
    /// <param name="domainEvent">The domain event to remove.</param>
    public void RemoveDomainEvent(DomainEvent domainEvent) => DomainEvents.Remove(domainEvent);

    /// <summary>
    /// Clears the list of associated domain events.
    /// </summary>
    public void ClearDomainEvents() => DomainEvents.Clear();
}
