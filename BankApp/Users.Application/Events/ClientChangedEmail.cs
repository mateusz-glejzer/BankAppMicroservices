using Users.Application.DTO;

namespace Users.Application.Events;

public class ClientChangedEmail : IEvent
{
    public UserDTO User { get; }

    public ClientChangedEmail(UserDTO user)
    {
        User = user;
    }
}