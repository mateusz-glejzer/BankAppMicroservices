using Accounts.Application.Queries;
using Accounts.Domain.Repositories;

namespace Accounts.Infrastructure.Handlers;

public class GetUserAccountsHandler : IQueryHandler<GetUserAccounts, IEnumerable<Guid>>
{
    private readonly IAccountRepository _repository;

    public GetUserAccountsHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Guid>> HandleAsync(GetUserAccounts query)
    {
        try
        {
            var result = await _repository.GetUserAccountsAsync(query.UserId);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}