using System.Text.Json;
using Microsoft.Extensions.Logging;
using Plain.RabbitMQ;
using IAccountRepository = Accounts.Domain.Repositories.IAccountRepository;

namespace Accounts.Application.Commands.Handlers;

public class CreateAccountHandler : ICommandHandler<CreateAccount>
{
    private readonly IPublisher _publisher;
    private readonly IAccountRepository _repository;
    private readonly ILogger<CreateAccountHandler> _logger;

    public CreateAccountHandler(IAccountRepository repository,ILogger<CreateAccountHandler> logger, IPublisher publisher)
    {
        _repository = repository;
        _logger = logger;
        _publisher = publisher;
    }

    public async Task HandleAsync(CreateAccount command)
    {
        try
        {
            await _repository.AddAsync(command.userId);
            _publisher.Publish(JsonSerializer.Serialize(new AccountCreated()),"account.exchange",null);
            _logger.LogInformation($"account created:{command.userId}");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}