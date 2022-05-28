namespace Users.Infrastructure.SqlServer.Entities;

public class UserEntity
{
    public IEnumerable<Guid> Accounts = new HashSet<Guid>();
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}