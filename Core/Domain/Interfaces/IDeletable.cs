namespace Core.Domain.Interfaces;

/// <summary>
/// Defines the properties required for a soft deletable entity.
/// </summary>
internal interface IDeletable
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted.
    /// </summary>
    bool Deleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was deleted.
    /// </summary>
    DateTime DeletedAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who deleted the entity.
    /// </summary>
    int DeletedBy { get; set; }
}
