using Accounts.Domain.Entities;
using Accounts.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastructure.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly AccountDbContext _context;
    private readonly IMapper _mapper;

    public AccountRepository(AccountDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Account> GetAsync(Guid id)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(account => account.AccountId == id);
        if (account is null)
        {
            //TODO implement this exception
            throw new Exception($"There is no account with Id: {id}");
        }

        return _mapper.Map<Account>(account);
    }

    public async Task<Guid> AddAsync(Guid userId,Currency currency)
    {
        var newAccount = new Account(userId, currency);
        await _context.Accounts.AddAsync(newAccount);
        return newAccount.AccountId;
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