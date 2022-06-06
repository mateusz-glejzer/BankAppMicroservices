using Users.Core.Repositories;

namespace Users.Infrastructure.Events.External.Handlers;

public class AccountStateChangedHandler : IEventHandler<AccountStateChanged>
{
    private readonly IUserRepository _repository;

    public AccountStateChangedHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task Handle(AccountStateChanged @event)
    {
        _repository.ChangeAccountState(@event.AccountNumber, @event.AccountState);
        return Task.CompletedTask;
    }
}