using EventPilot.Domain.Common;
using EventPilot.Domain.Enums;

namespace EventPilot.Domain.Entities;

public class TenantStaff : BaseEntity
{
    public Guid TenantId { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Fullname { get; private set; } = string.Empty;
    public Staffrole StaffRole { get; private set; } = Staffrole.Member;
    public string? AvatarUrl { get; private set; }
    public bool IsActive { get; private set; } = true;
    
    private TenantStaff() { }

    public static TenantStaff Create(Guid tenantId, string username, string email, string fullname)
    {
        if (tenantId == Guid.Empty)
            throw new ArgumentException("TenantId is required", nameof(tenantId));
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username is required", nameof(username));
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required", nameof(email));
        if (string.IsNullOrWhiteSpace(fullname))
            throw new ArgumentException("Fullname is required", nameof(fullname));

        return new TenantStaff
        {
            TenantId = tenantId,
            Username = username.Trim(),
            Email = email.Trim().ToLower(),
            Fullname = fullname.Trim(),
            StaffRole = Staffrole.Member,
            IsActive = true
        };
    }
    
    public void UpdateProfile(string fullname, string? avatarUrl)
    {
        Fullname = fullname;
        AvatarUrl = avatarUrl;
    }

    public void ChangeRole(Staffrole newRole)
    {
        StaffRole = newRole;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}