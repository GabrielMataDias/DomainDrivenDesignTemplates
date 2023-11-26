namespace Core.Domain.Interfaces;
/// <summary>
/// Defines the properties for version control of an entity.
/// </summary>
internal interface IVersioned
{
    /// <summary>
    /// Gets or sets the version number of the entity.
    /// </summary>
    // [RowVersion]
    byte[] Version { get; set; }
}
