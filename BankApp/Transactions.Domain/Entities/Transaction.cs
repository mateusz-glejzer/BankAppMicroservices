using System.Numerics;

namespace Transactions.Domain.Entities;

public class Transaction
{
    public Guid TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public Guid Sender { get; set; }
    public Guid Receiver { get; set; }
    public BigInteger TransactionAmount { get; set; }
    public State State { get; set; }

    public Transaction(BigInteger transactionAmount, BigInteger balance, Guid sender, Guid receiver, State state)
    {
        TransactionAmount = transactionAmount;
        Sender = sender;
        Receiver = receiver;
        State = state;
        TransactionId = new Guid();
        TransactionDate = DateTime.Now;
    }
}