namespace Accounts.Application.Commands;

public record UnlockAccount(Guid BankAccount) : ICommand;