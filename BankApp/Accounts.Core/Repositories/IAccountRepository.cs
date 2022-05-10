namespace Accounts.Core.Repositories;

public interface IAccountRepository
{
    Task<AccountService> GetAsync(Guid id);
    Task AddAsync(AccountService accountService);
    Task ChangeAsync(AccountService accountService);
    Task DeleteAsync(AccountService accountService);
    Task<IReadOnlyList<AccountService>> BrowseAsync();
}