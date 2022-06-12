namespace Users.Core.Entities;

public class User
{
    public List<Guid> Accounts = new();
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}