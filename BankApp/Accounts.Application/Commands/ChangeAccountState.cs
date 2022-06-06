using Accounts.Domain.Entities;

namespace Accounts.Application.Commands;

public record ChangeAccountState(Guid BankAccount, AccountState State) : ICommand;