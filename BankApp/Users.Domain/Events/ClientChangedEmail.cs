using Users.Core.Entities;

namespace Users.Core.Events;

public class ClientChangedEmail:IDomainEvent
{
    public User User { get; }

    public ClientChangedEmail(User user)
    {
        User = user;
    }
    
}