namespace Accounts.Core.Repositories;

public class AccountRepository : IAccountRepository
{
    public Task<AccountService> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(AccountService accountService)
    {
        throw new NotImplementedException();
    }

    public Task ChangeAsync(AccountService accountService)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(AccountService accountService)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<AccountService>> BrowseAsync()
    {
        throw new NotImplementedException();
    }
}