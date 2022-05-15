using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounts.Domain.Entities;

namespace Accounts.Domain.Repositories;

public class AccountRepository : IAccountRepository
{
    public Task<Account> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Account account)
    {
        throw new NotImplementedException();
    }

    public Task ChangeAsync(Account account)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Account account)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Account>> BrowseAsync()
    {
        throw new NotImplementedException();
    }
}