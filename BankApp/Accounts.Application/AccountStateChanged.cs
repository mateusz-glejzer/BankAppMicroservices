using Accounts.Domain.Entities;

namespace Accounts.Application;

public class AccountStateChanged
{
    public Guid AccountNumber { get; set; }
    public AccountState AccountState { get; set; }

    public AccountStateChanged(AccountState accountState, Guid accountNumber)
    {
        AccountState = accountState;
        AccountNumber = accountNumber;
    }
}