namespace Accounts.Core.Commands;

public record UnlockAccount(Guid BankAccount) : ICommand;