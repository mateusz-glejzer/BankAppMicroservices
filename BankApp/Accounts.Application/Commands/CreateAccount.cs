namespace Accounts.Application.Commands;

public record CreateAccount(Guid userId) : ICommand;