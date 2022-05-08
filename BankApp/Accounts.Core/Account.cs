namespace Accounts.Core;

public class Account
{
    public Guid AccountId { get; }
    public Guid UserId { get; }
    public Currency Currency { get; set; }
    public double Balance { get; set; }
    public bool IsLocked { get; set; }

    public Account(Guid userId,Currency currency)
    {
        AccountId = new Guid();
        UserId = userId;
        Currency = currency;
    }

    public void ReduceBalance(int amount) => Balance -= amount;
    public void IncreaseBalance(int amount) => Balance += amount;
    public void LockAccount() => IsLocked = true;
    public void Unlock() => IsLocked = false;
}