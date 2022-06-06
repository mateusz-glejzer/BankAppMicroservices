using Accounts.Domain.Entities;

namespace Accounts.Application.Queries;

public record GetAccounts(Guid UserId) : IQuery<IReadOnlyList<Account>>;