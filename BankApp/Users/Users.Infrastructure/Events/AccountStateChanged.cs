
using Users.Core.Entities;

namespace Users.Infrastructure.Events;

public class AccountStateChanged : IEvent
{
    public Guid AccountNumber { get; set; }
    public AccountState AccountState { get; set; }

    public AccountStateChanged(AccountState accountState, Guid accountNumber)
    {
        AccountState = accountState;
        AccountNumber = accountNumber;
    }
}