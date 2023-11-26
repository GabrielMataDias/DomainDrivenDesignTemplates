using Core.Domain.Abstracts;

namespace Core.Domain.ValueObjects;

/// <summary>
/// Represents the NamedDescription data as a value object in the domain.
/// </summary>
internal sealed record NamedDescription : ValueObject
{
    private const ushort MaxLengthName = 20;
    private const ushort MaxLengthDescription = 250;

    public string Name { get; private set; }
    public string Description { get; private set; }

    /// <summary>
    /// Initializes a new instance of the NamedDescription record class.
    /// </summary>
    /// <param name="name">The NamedDescription name.</param>
    /// <param name="description">The NamedDescription description.</param>
    private NamedDescription(string name, string description)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Creates a new NamedDescription object after validating the input parameters.
    /// </summary>
    /// <param name="name">The NamedDescription name.</param>
    /// <param name="Description">The NamedDescription Description.</param>
    /// <returns>A new NamedDescription object.</returns>
    /// <exception cref="ArgumentException">Thrown when the name or Description is null, empty, or exceeds maximum length.</exception>
    public static NamedDescription Create(string name, string description)
    {
        ValidateProperty(value: name, maxLength: MaxLengthName, paramName: nameof(name));
        ValidateProperty(value: description, maxLength: MaxLengthDescription, paramName: nameof(Description));

        return new NamedDescription(name, description);
    }

    private static void ValidateProperty(string value, ushort maxLength, string paramName)
    {
        EnforceStringNotNullOrWhiteSpace(value, paramName);
        EnforceStringMaxLength(value, maxLength, paramName);
    }

    private static void EnforceStringNotNullOrWhiteSpace(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(message: $"The {paramName} must not be null or whitespace.");
    }

    private static void EnforceStringMaxLength(string value, ushort maxLength, string paramName)
    {
        if (value.Length > maxLength)
            throw new ArgumentException(message: $"{paramName} must be between 1 and {maxLength} characters.");
    }

    /// <summary>
    /// Gets the atomic values of the NamedDescription object.
    /// </summary>
    /// <returns>A collection of atomic values.</returns>
    public override IReadOnlyCollection<object> GetAtomicValues() => new object[] { Name, Description };
}
