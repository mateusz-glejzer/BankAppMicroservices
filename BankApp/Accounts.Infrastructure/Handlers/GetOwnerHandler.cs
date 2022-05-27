using Accounts.Application.Queries;

namespace Accounts.Infrastructure.Handlers;

public class GetOwnerHandler:IQueryHandler<GetOwnerId,Guid>
{
    public Task<Guid> HandleAsync(GetOwnerId query)
    {
        throw new NotImplementedException();
    }
}