namespace Accounts.Core.Commands;

public record IncreaseBalance(Guid BankAccount, int Amount) : ICommand;