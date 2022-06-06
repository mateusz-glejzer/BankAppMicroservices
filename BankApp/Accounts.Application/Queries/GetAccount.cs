using Accounts.Domain.Entities;

namespace Accounts.Application.Queries;

public record GetAccount(Guid AccountId) : IQuery<Account>;
