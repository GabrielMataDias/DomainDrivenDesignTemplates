using Core.Domain.Abstracts;

namespace Core.Domain.ValueObjects;

/// <summary>
/// Represents the credentials data as a value object in the domain.
/// </summary>
internal sealed record Credentials : ValueObject
{
    private const ushort MaxLengthName = 20;
    private const ushort MaxLengthPassword = 8;

    public string Name { get; private set; }
    public string Password { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Credentials record class.
    /// </summary>
    /// <param name="name">The credentials name.</param>
    /// <param name="password">The credentials password.</param>
    private Credentials(string name, string password)
    {
        Name = name;
        Password = password;
    }

    /// <summary>
    /// Creates a new Credentials object after validating the input parameters.
    /// </summary>
    /// <param name="name">The credentials name.</param>
    /// <param name="password">The credentials password.</param>
    /// <returns>A new Credentials object.</returns>
    /// <exception cref="ArgumentException">Thrown when the name or password is null, empty, or exceeds maximum length.</exception>
    public static Credentials Create(string name, string password)
    {
        ValidateProperty(value: name, maxLength: MaxLengthName, paramName: nameof(name));
        ValidateProperty(value: password, maxLength: MaxLengthPassword, paramName: nameof(password));

        return new Credentials(name, password);
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
    /// Gets the atomic values of the Credentials object.
    /// </summary>
    /// <returns>A collection of atomic values.</returns>
    public override IReadOnlyCollection<object> GetAtomicValues() => new object[] { Name, Password };
}
