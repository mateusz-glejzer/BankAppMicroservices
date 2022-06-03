using Users.Application.DTO;
using Users.Core;

namespace Users.Application.Events;

public class ClientChangedEmail : IDomainEvent
{
    public UserDTO User { get; }

    public ClientChangedEmail(UserDTO user)
    {
        User = user;
    }
}