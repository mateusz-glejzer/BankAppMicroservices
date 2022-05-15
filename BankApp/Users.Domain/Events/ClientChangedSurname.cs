using Users.Core.Entities;

namespace Users.Core.Events;

public class ClientChangedSurname : IDomainEvent
{
    public ClientChangedSurname(User user)
    {
        User = user;
    }

    public User User { get; }
}