using Microsoft.Extensions.Logging;
using Users.Core.Repositories;

namespace Users.Infrastructure.Events.External.Handlers;

public class AccountCreatedHandler:IEventHandler<AccountCreated>
{
    private readonly IUserRepository _repository;
    private readonly ILogger _logger;

    public AccountCreatedHandler(IUserRepository repository,ILogger<AccountCreatedHandler> _logger)
    {
         _repository = repository;
        this._logger = _logger;
    }

    public async Task HandleAsync(AccountCreated @event)
    {
        var user = await _repository.GetUser(@event.UserId);
        user.AddAccount(@event.BankAccountId);
        await _repository.ChangeUser(user);
        _logger.LogInformation($"Account added:{@event.BankAccountId} to user {@event.UserId}");

    }
}