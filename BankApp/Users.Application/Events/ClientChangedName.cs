using Users.Application.DTO;

namespace Users.Application.Events;

public class ClientChangedName : IEvent
{
    public ClientChangedName(UserDTO user)
    {
        User = user;
    }

    public UserDTO User { get; }
}