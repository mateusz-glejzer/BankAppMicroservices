using Users.Application.DTO;
using Users.Core;

namespace Users.Application.Events;

public class ClientChangedName : IDomainEvent
{
    public ClientChangedName(UserDTO user)
    {
        User = user;
    }

    public UserDTO User { get; }
}