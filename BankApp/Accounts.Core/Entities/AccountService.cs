namespace Accounts.Core;

public class AccountService
{
    public void ReduceBalance(Guid bankAccount, int amount) => ;
    public void IncreaseBalance(Guid bankAccount, int amount) => Balance += amount;
    public void LockAccount(Guid bankAccount) => IsLocked = true;
    public void Unlock(Guid bankAccount) => IsLocked = false;
}