using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounts.Domain.Entities;

namespace Accounts.Domain.Repositories;

public interface IAccountRepository
{
    Task<Account> GetAsync(Guid id);
    Task AddAsync(Guid userId);
    Task ChangeAsync(Account account);
    Task DeleteAsync(Account account);
    Task<IReadOnlyList<Account>> BrowseAsync();
}