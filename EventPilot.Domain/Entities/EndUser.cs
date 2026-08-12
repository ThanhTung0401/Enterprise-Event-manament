using EventPilot.Domain.Enums;
using EventPilot.Domain.Common;

namespace EventPilot.Domain.Entities;

public class EndUser : BaseEntity
{
    public string Username { get; private set; } =  string.Empty;
    public string Email { get; private set; } =  string.Empty;
    public string Fullname { get; private set; } =  string.Empty;
    public string? PhoneNumber { get; private set; }
    public string? AvatarUrl { get; private set; }
    public Gender? Gender { get; private set; }
    public UserPlanStatus Plan { get; private set; } = UserPlanStatus.Basic;
    
    private EndUser() { }

    public static EndUser Create(string username, string email, string fullname)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username is required", nameof(username));
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is requires", nameof(email));
        if (string.IsNullOrWhiteSpace(fullname))
            throw new ArgumentException("Fullname is required", nameof(fullname));

        return new EndUser
        {
            Username = username.Trim(),
            Email = email.Trim().ToLower(),
            Fullname = fullname,
            Plan = UserPlanStatus.Basic,
        };
    }

    public void UpdateProfile(string fullName, string? phoneNumber, Gender? gender, string? avatarUrl)
    {
        Fullname = fullName;
        PhoneNumber = phoneNumber;
        Gender = gender;
        AvatarUrl = avatarUrl;
    }

    public void ChangePlan(UserPlanStatus newPlan)
    {
        Plan = newPlan;
    }
}

