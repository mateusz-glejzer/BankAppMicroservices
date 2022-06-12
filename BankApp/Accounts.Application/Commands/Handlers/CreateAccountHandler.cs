using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using IAccountRepository = Accounts.Domain.Repositories.IAccountRepository;

namespace Accounts.Application.Commands.Handlers;

public class CreateAccountHandler : ICommandHandler<CreateAccount>
{
    private readonly IPublisher _publisher;
    private readonly IAccountRepository _repository;
    private readonly ILogger<CreateAccountHandler> _logger;

    public CreateAccountHandler(IAccountRepository repository, ILogger<CreateAccountHandler> logger,
        IPublisher publisher)
    {
        _repository = repository;
        _logger = logger;
        _publisher = publisher;
    }

    public async Task HandleAsync(CreateAccount command)
    {
        try
        {
            var accountId = await _repository.AddAsync(command.UserId, command.Currency);
            var newAccount = new AccountCreated() {UserId = command.UserId, BankAccountId = accountId};
            var message = JsonConvert.SerializeObject(newAccount);

            _publisher.Publish(message, "account.create", null);
            _logger.LogInformation($"account created:{command.UserId}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}