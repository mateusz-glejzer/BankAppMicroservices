namespace Accounts.Core.Dto;

public class AccountDto
{
    public Guid AccountId { get; set; }
    public Guid UserId { get; set; }
    public CurrencyDto Currency { get; set; }
    public bool IsLocked { get; set; }
}