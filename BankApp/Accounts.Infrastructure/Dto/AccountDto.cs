using System.ComponentModel.DataAnnotations;
using Accounts.Domain.Entities;

namespace Accounts.Infrastructure.Dto;

public class AccountDto
{
    [Key] public Guid AccountId { get; set; }
    public Guid UserId { get; set; }
    public Currency Currency { get; }
    public Double Balance { get; set; }

    public AccountState State { get; set; }
}