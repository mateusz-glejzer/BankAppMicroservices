using System.Numerics;

namespace Accounts.Application.Commands;

public record ChangeBalance(Guid BankAccount, BigInteger Amount):ICommand;