namespace Users.Application.Events.External;

public class AccountCreated : IEvent
{
    public Guid BankAccountId { get; }
    public Guid UserId { get; }

    public AccountCreated(Guid bankAccountId, Guid userId)
    {
        BankAccountId = bankAccountId;
        UserId = userId;
    }
}