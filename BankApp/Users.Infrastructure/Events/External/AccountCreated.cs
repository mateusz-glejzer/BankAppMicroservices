namespace Users.Infrastructure.Events.External;

public class AccountCreated : IEvent
{
    public Guid BankAccountId;
    public Guid UserId;
}