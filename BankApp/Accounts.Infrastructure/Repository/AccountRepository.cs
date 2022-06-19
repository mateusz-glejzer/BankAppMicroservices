using Accounts.Domain.Entities;
using Accounts.Domain.Repositories;
using Accounts.Infrastructure.Dto;
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
        try
        {
            var account = await _context.Accounts.FirstAsync(account => account.AccountId == id);

            return _mapper.Map<Account>(account);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<IEnumerable<Guid>> GetUserAccountsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddAsync(Guid userId, Currency currency)
    {
        var newAccount = new Account(userId, currency);
         var newAccountDto = _mapper.Map<AccountDto>(newAccount);
        await _context.Accounts.AddAsync(newAccountDto);
        return newAccount.AccountId;
    }
}