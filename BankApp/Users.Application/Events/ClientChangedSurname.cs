using Users.Application.DTO;

namespace Users.Application.Events;

public class ClientChangedSurname : IEvent
{
    public ClientChangedSurname(UserDTO user)
    {
        User = user;
    }

    public UserDTO User { get; }
}