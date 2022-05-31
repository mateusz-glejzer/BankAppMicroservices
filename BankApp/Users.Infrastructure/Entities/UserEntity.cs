using System.ComponentModel.DataAnnotations;

namespace Users.Infrastructure.Entities;

public class UserEntity
{
    [Key] 
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public List<Guid> Accounts = new();
}