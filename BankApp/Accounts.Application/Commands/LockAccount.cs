using Accounts.Domain.Entities;

namespace Accounts.Application.Commands;

public record LockAccount(Account BankAccount) : ICommand;