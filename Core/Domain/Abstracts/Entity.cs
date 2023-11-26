namespace Core.Domain.Abstracts;
/// <summary>
/// Represents the base class for entities in the domain.
/// Provides common functionalities like equality checks based on the unique identifier.
/// </summary>
internal abstract class Entity : IEquatable<Entity>
{
    /// <summary>
    /// Gets the unique identifier for the entity. This is typically set by the database when the entity is persisted.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Compares two entities for equality based on their identifiers.
    /// </summary>
    /// <param name="first">The first entity to compare.</param>
    /// <param name="second">The second entity to compare.</param>
    /// <returns>true if both entities are equal; otherwise, false.</returns>
    public static bool operator ==(Entity? first, Entity? second)
        => ReferenceEquals(first, second) || (first?.Equals(second) == true);

    /// <summary>
    /// Compares two entities for inequality based on their identifiers.
    /// </summary>
    /// <param name="first">The first entity to compare.</param>
    /// <param name="second">The second entity to compare.</param>
    /// <returns>true if both entities are not equal; otherwise, false.</returns>
    public static bool operator !=(Entity? first, Entity? second) => !(first == second);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is Entity entity && (ReferenceEquals(this, obj) || Id == entity.Id);

    /// <inheritdoc/>
    public override int GetHashCode() => Id.GetHashCode();

    /// <inheritdoc/>
    public override string ToString() => $"Entity of type {GetType().Name} with ID: {Id}";

    /// <inheritdoc/>
    public bool Equals(Entity? other)
        => other is not null && (ReferenceEquals(this, other) || Id == other.Id);
}

