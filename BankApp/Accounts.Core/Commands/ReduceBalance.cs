namespace Accounts.Core.Commands;

public record ReduceBalance(Guid BankAccount, int Amount) : ICommand;