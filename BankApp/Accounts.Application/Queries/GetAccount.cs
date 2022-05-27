using Accounts.Domain.Entities;

namespace Accounts.Application.Queries;

public record GetAccount : IQuery<Account>
{
    public Guid UserId { get; set; }
}
