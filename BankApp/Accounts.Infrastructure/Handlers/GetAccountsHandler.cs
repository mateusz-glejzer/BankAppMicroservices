using Accounts.Application.Queries;
using Accounts.Domain.Entities;

namespace Accounts.Infrastructure.Handlers;

public class GetAccountsHandler:IQueryHandler<GetAccounts,IReadOnlyList<Account>>
{
    public Task<IReadOnlyList<Account>> HandleAsync(GetAccounts query)
    {
        throw new NotImplementedException();
    }
}