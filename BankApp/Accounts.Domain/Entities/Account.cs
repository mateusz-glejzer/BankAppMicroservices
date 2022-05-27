using System;
using System.Numerics;

namespace Accounts.Domain.Entities;

public class Account
{
    public Guid AccountId { get; }
    public Guid UserId { get; }
    public Currency Currency { get; }
    public BigInteger Balance { get; set; }
    public bool IsLocked { get; set; }

    public Account(Guid userId, Currency currency)
    {
        UserId = userId;
        Currency = currency;
        IsLocked = false;
        AccountId = new Guid();
    }
}