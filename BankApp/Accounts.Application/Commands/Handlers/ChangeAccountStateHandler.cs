using Accounts.Domain.Repositories;
using Newtonsoft.Json;
using Plain.RabbitMQ;

namespace Accounts.Application.Commands.Handlers;

public class ChangeAccountStateHandler : ICommandHandler<ChangeAccountState>
{
    private readonly IAccountRepository _repository;
    private readonly IPublisher _publisher;

    public ChangeAccountStateHandler(IAccountRepository repository, IPublisher publisher)
    {
        _repository = repository;
        _publisher = publisher;
    }

    public async Task HandleAsync(ChangeAccountState command)
    {
        var bankAccount = await _repository.GetAsync(command.BankAccount);
        bankAccount.State = command.State;
        await _repository.ChangeAsync(bankAccount);
        var @event = new AccountStateChanged(bankAccount.State,bankAccount.AccountId);
        var message = JsonConvert.SerializeObject(@event);
        _publisher.Publish(message,"account.state",null);
        
    }
}