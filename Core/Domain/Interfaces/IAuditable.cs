namespace Core.Domain.Interfaces;
/// <summary>
/// Defines the properties required for an auditable entity.
/// This includes information about when and by whom the entity was created or last updated.
/// </summary>
internal interface IAuditable
{
    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who created the entity.
    /// </summary>
    int CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who last updated the entity.
    /// </summary>
    int LastUpdatedBy { get; set; }
}
