using Accounts.Domain.Entities;
using Accounts.Domain.Repositories;

namespace Accounts.Infrastructure.Repository;

public class AccountRepository:IAccountRepository
{
    public Task<Account> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Guid userId)
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