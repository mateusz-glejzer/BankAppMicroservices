namespace Users.Core.Entities;

public class User
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public User(string name, string surname, string email)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Id = new Guid();
    }
}