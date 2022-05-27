using Accounts.Application.Queries;

namespace Accounts.Infrastructure.Handlers;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : class, IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}