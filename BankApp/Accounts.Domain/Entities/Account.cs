using System;

namespace Accounts.Domain.Entities;

public class Account
{
    public Guid AccountId { get; }
    public Guid UserId { get; }
    public Currency Currency { get; }
    public Double Balance { get; set; }
    
    public AccountState State { get; set; }

    public Account(Guid userId, Currency currency)
    {
        UserId = userId;
        Currency = currency;
        AccountId = new Guid();
    }
}