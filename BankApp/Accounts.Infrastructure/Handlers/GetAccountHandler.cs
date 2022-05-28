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

    public Task<Account> HandleAsync(GetAccount query)
    {
        var userFromDb = _repository.GetAsync(query.UserId);
        return userFromDb;
    }
}