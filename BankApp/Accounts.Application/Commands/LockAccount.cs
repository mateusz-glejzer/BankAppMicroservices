namespace Accounts.Application.Commands;

public record LockAccount(Guid BankAccount) : ICommand;