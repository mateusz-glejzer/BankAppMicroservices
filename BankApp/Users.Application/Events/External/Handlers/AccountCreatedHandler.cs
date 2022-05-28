using Users.Core.Repositories;

namespace Users.Application.Events.External.Handlers;

public class AccountCreatedHandler:IEventHandler<AccountCreated>
{
    private readonly IUserRepository _repository;

    public AccountCreatedHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(AccountCreated @event)
    {
        var user = await _repository.GetAsync(@event.UserId);
        user.
    }
}