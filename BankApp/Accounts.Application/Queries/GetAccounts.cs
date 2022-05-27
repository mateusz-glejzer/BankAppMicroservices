using Accounts.Domain.Entities;

namespace Accounts.Application.Queries;

public record GetAccounts : IQuery<IReadOnlyList<Account>>;