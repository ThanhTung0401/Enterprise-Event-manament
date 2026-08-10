namespace EventPilot.Domain.Common;

public abstract class FullAuditableEntity
{
    public bool IsDeleted { get; set; }
    public DateTime DeletedAt { get; set; }
    public int? DeletedBy { get; set; }
}