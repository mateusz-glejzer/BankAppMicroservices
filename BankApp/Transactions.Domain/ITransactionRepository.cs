using Transactions.Domain.Entities;
using Transaction = System.Transactions.Transaction;

namespace Transactions.Domain;

public interface ITransactionRepository
{
    public Task Create(Transaction transaction);
    public Task ChangeState(Guid id, State state);
    public Task<Entities.Transaction> GetTransaction(Guid id);
    public Task<IReadOnlyList<Entities.Transaction>> GetUserTransactions(Guid userId);
}