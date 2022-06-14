using System;
using System.Threading.Tasks;
using Accounts.Domain.Entities;

namespace Accounts.Domain.Repositories;

public interface IAccountRepository
{
    Task<Account> GetAsync(Guid id);
    Task<Guid> AddAsync(Guid userId,Currency currency);
}