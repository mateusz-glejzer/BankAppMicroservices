namespace Accounts.Core.Commands;

public record LockAccount(Guid BankAccount) : ICommand;