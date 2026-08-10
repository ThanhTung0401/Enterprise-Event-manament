namespace EventPilot.Domain.Common;

/// <summary>
/// Here is the base entity for tables which track the changes 
/// </summary>
public abstract class AuditableEntity : BaseEntity
{
    public DateTime? UpdateAt { get; set; }
    
    public int? UpdateBy { get; set; }
}