using Users.Application.DTO;
using Users.Core;

namespace Users.Application.Events;

public class ClientChangedSurname : IDomainEvent
{
    public ClientChangedSurname(UserDTO user)
    {
        User = user;
    }

    public UserDTO User { get; }
}