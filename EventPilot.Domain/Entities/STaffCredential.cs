using EventPilot.Domain.Common;
using EventPilot.Domain.Enums;

namespace EventPilot.Domain.Entities;

public class StaffCredential : BaseEntity
{
    public Guid StaffId { get; private set; }
    public string PasswordHash { get; private set; } = string.Empty;
    public TenantStaff? Staff { get; private set; }  
    
    private StaffCredential() { }

    public static StaffCredential Create(Guid staffId, string passwordHash)
    {
        if(staffId == Guid.Empty)
            throw new ArgumentException($"{nameof(staffId)} cannot be empty", nameof(staffId));
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException($"{nameof(passwordHash)} cannot be empty", nameof(passwordHash));
        return new StaffCredential
        {
            StaffId = staffId,
            PasswordHash = passwordHash,
        };
    }
    
    public void UpdatePasswordHash(string NewpasswordHash)
    {
        if(string.IsNullOrWhiteSpace(NewpasswordHash))
            throw new ArgumentException($"{nameof(NewpasswordHash)} cannot be empty", nameof(NewpasswordHash));
        PasswordHash = NewpasswordHash;
    }
}