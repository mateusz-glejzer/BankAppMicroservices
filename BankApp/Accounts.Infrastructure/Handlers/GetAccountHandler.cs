using Accounts.Application.Queries;
using Accounts.Domain.Entities;
using Accounts.Domain.Repositories;

namespace Accounts.Infrastructure.Handlers;

public class GetAccountHandler : IQueryHandler<GetAccount, Account>
{
    private readonly IAccountRepository _repository;

    public GetAccountHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<Account> HandleAsync(GetAccount query)
    {
        try
        {
            var result=  await _repository.GetAsync(query.AccountId);
            return result;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}