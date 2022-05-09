
namespace Loans.Core;

public class Loan
{
    public Loan(Guid id, Guid accountNumber, double totalLoan, DateTime startDate, DateTime repaymentDate)
    {
        Id = new Guid();
        AccountNumber = accountNumber;
        TotalLoan = totalLoan;
        StartDate = startDate;
        RepaymentDate = repaymentDate;
    }

    public Guid Id { get; }
    public Guid AccountNumber { get; }
    public double TotalLoan { get; }
    public double AmountToPay { get; set; }
    public DateTime StartDate { get; }
    public DateTime RepaymentDate { get; }
    public uint Version { get; }
}