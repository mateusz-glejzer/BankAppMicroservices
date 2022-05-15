namespace Accounts.Core.Queries.Handlers;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : class, IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}