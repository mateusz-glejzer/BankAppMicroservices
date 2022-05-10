namespace Accounts.Core.Dto;

public class Account
{
    public Guid AccountId { get; set; }
    public Guid UserId { get; set; }
    public Currency Currency { get; set; }
    public double Balance { get; set; }
    public bool IsLocked { get; set; }
}