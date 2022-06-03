using Users.Core.Entities;

namespace Users.Core.Events;

public class ClientChangedName : IDomainEvent
{
    public ClientChangedName(User user)
    {
        User = user;
    }

    public User User { get; }
}