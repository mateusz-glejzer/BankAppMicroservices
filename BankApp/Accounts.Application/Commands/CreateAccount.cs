using Accounts.Domain.Entities;

namespace Accounts.Application.Commands;

public record CreateAccount(Guid UserId,Currency Currency) : ICommand;