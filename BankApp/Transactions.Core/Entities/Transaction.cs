using System.Numerics;

namespace Transactions.Core.Entities;

public class Transaction
{
    public Guid TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public Guid AccountNumber { get; set; }
    public BigInteger TransactionAmount { get; set; }
    public BigInteger Balance { get; set; }

    public Transaction(Guid accountNumber, BigInteger transactionAmount, BigInteger balance)
    {
        AccountNumber = accountNumber;
        TransactionAmount = transactionAmount;
        Balance = balance;
        TransactionId = new Guid();
        TransactionDate = DateTime.Now;
    }
}