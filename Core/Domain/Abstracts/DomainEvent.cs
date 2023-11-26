namespace Core.Domain.Abstracts;
/// <summary>
/// Represents a base class for domain events in the Domain-Driven Design (DDD) architecture.
/// Domain events capture and represent meaningful changes or occurrences within the domain.
/// </summary>
internal abstract class DomainEvent
{
    /// <summary>
    /// Gets the timestamp when the domain event occurred.
    /// </summary>
    public DateTime OccurredAt { get; }
}
