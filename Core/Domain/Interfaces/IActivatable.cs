namespace Core.Domain.Interfaces;
/// <summary>
/// Defines the properties and methods for entities that can be activated or deactivated.
/// </summary>
internal interface IActivatable
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity is active.
    /// </summary>
    bool IsActive { get; set; }
}
