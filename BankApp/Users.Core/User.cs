namespace Users.Core;

public class User
{
    public Guid Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public string Email { get; }
    public IEnumerable<Guid> AccountsId { get; }
    public uint Version { get; }

    public User(string name, string surname, string email)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Id = new Guid();
    }
}