using System.Transactions;

namespace Transactions.Application.Commands;

public record CreateTransaction(Transaction Transaction):ICommand;