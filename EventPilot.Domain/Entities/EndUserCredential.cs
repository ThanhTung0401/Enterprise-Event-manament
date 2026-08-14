using EventPilot.Domain.Common;
using EventPilot.Domain.Enums;

namespace EventPilot.Domain.Entities;

public class EndUserCredential : BaseEntity
{
    public Guid UserId { get; private set; }
    public string PasswordHash { get; private set; } =  string.Empty;

    public EndUser User { get; private set; } = null;
    
    private  EndUserCredential() { }

    public static EndUserCredential Create(Guid userId, string passwordHash)
    {
        if( userId == Guid.Empty )
            throw new ArgumentException( $"{nameof(userId)} cannot be empty", nameof( userId ) );
        if ( string.IsNullOrEmpty( passwordHash ) )
            throw new ArgumentException( $"{nameof(passwordHash)} cannot be empty", nameof( passwordHash ) );

        return new EndUserCredential
        {
            UserId = userId,
            PasswordHash = passwordHash,
        };
    }
    
    public void UpdatePasswordHash( string NewpasswordHash )
    {
        if( string.IsNullOrWhiteSpace( NewpasswordHash ) )
            throw new ArgumentException( $"{nameof(NewpasswordHash)} cannot be empty", nameof( NewpasswordHash ) );
        PasswordHash = NewpasswordHash;
    }
    
}