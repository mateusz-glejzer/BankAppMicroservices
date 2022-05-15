using Users.Core.Events;

namespace Users.Core.Entities;

public class User : AggregateRoot
{
    public IEnumerable<Guid> Accounts = new HashSet<Guid>();
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }

    public User(string name, string surname, string email)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Id = new Guid();
    }

    public void ChangeName(string name)
    {
        Name = name;
        AddEvent(new ClientChangedName(this));
    }

    public void ChangeEmail(string email)
    {
        Email = email;
        AddEvent(new ClientChangedEmail(this));
    }

    public void ChangeSurname(string surname)
    {
        Surname = surname;
        AddEvent(new ClientChangedSurname(this));
    }
}