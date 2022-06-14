namespace Accounts.Application.Queries;

public record GetUserAccounts(Guid UserId) : IQuery<IEnumerable<Guid>>;