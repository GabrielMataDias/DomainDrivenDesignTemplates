namespace Core.Domain.Abstracts;

/// <summary>
/// Represents the base class for value objects in the domain.
/// Value objects are compared based on their atomic values, not their identity.
/// </summary>
internal abstract record ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// When overridden in a derived class, gets an IReadOnlyCollection of objects that represent
    /// the atomic values of the value object.
    /// </summary>
    /// <returns>An IReadOnlyCollection of objects representing the atomic values.</returns>
    public abstract IReadOnlyCollection<object> GetAtomicValues();

    /// <inheritdoc/>
    public override int GetHashCode() => 
        GetAtomicValues().Aggregate(seed: 0, func: (int current, object obj) => HashCode.Combine(current, obj?.GetHashCode()));

    /// <inheritdoc/>
    public override string ToString() => 
        $"{GetType().Name}[{string.Join(separator: ", ", values: GetAtomicValues())}]";
}
