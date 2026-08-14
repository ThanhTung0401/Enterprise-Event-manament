using EventPilot.Domain.Common;

namespace EventPilot.Domain.Entities;

public class EndUserSocialAccount : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Provider { get; private set; } =  string.Empty;
    public string ProviderUserId { get; private set; } = string.Empty;
    public EndUser? User { get; private set; }
    
    private EndUserSocialAccount() { }

    public EndUserSocialAccount Create(Guid userId, string provider, string providerUserId)
    {
        if(userId == Guid.Empty)
            throw new ArgumentException($"{nameof(userId)} cannot be empty", nameof(userId));
        if(string.IsNullOrWhiteSpace(provider))
            throw new ArgumentException($"{nameof(provider)} cannot be empty", nameof(provider));
        if (string.IsNullOrWhiteSpace(providerUserId))
            throw new ArgumentException($"{providerUserId} cannot be empty", nameof(providerUserId));

        return new EndUserSocialAccount
        {
            UserId = userId,
            Provider = provider,
            ProviderUserId = providerUserId,
        };
    }

    public void UpdateUserAccount(string Newprovider, string NewproviderUserId, EndUser? user)
    {
        Provider = Newprovider;
        ProviderUserId = NewproviderUserId;
    } 
        
}