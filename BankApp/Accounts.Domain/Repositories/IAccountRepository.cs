using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounts.Domain.Entities;

namespace Accounts.Domain.Repositories;

public interface IAccountRepository
{
    Task<Account> GetAsync(Guid id);
    Task<IEnumerable<Guid>> GetUserAccountsAsync(Guid userId);
    Task<Guid> AddAsync(Guid userId,Currency currency);
}