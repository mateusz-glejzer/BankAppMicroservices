using System.ComponentModel.DataAnnotations;
namespace Users.Infrastructure.Entities;

public class UserAccount
{
    [Key] public Guid Id { get; set; }
    public UserEntity UserEntity { get; set; }
    public Guid AccountNumber { get; set; }
}