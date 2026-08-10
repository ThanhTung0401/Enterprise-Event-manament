namespace EventPilot.Domain.Common;
/// <summary>
/// Here is the base entity for tables which track Soft Delete
/// </summary>
public abstract class FullAuditableEntity
{
    public bool IsDeleted { get; set; }
    public DateTime DeletedAt { get; set; }
    public int? DeletedBy { get; set; }
}