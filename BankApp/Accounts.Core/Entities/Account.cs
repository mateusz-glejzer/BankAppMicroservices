namespace Accounts.Core;

public class Account
{
    public Guid AccountId { get; }
    public Guid UserId { get; }
    public Currency Currency { get; set; }
    public double Balance { get; set; }
    public bool IsLocked { get; set; }

    public uint Version { get; set; }

    public Account(Guid userId, Currency currency)
    {
        AccountId = new Guid();
        UserId = userId;
        Currency = currency;
        Version = 1;
    }

    public Account(Guid accountId, Guid userId, Currency currency, double balance, bool isLocked, uint version)
    {
        AccountId = accountId;
        UserId = userId;
        Currency = currency;
        Balance = balance;
        IsLocked = isLocked;
        Version = version;
    }
    
    public void ReduceBalance(int amount) => Balance -= amount;
    public void IncreaseBalance(int amount) => Balance += amount;
    public void LockAccount() => IsLocked = true;
    public void Unlock() => IsLocked = false;
}