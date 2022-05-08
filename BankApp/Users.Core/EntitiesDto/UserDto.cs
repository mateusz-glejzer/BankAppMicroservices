namespace Users.Core.EntitiesDto;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public IEnumerable<Guid> AccountsId { get; set; }
}