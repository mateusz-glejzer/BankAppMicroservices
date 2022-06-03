using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Plain.RabbitMQ;
using Users.Infrastructure.Events.External;
using Users.Infrastructure.Events.External.Handlers;

namespace Users.Infrastructure;

public class AccountCollector : IHostedService
{
    private readonly ISubscriber _subscriber;

    private readonly AccountCreatedHandler _accountCreatedHandler;
    private readonly ILogger<AccountCollector> _logger;

    public AccountCollector(ISubscriber subscriber, ILogger<AccountCollector> logger,
        AccountCreatedHandler accountCreatedHandler)
    {
        _subscriber = subscriber;
        _logger = logger;
        _accountCreatedHandler = accountCreatedHandler;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _subscriber.SubscribeAsync(ProcessMessage);
        return Task.CompletedTask;
    }

    private async Task<bool> ProcessMessage(string message, IDictionary<string, object> headers)
    {
        var @event = JsonSerializer.Deserialize<AccountCreated>(message);
        await _accountCreatedHandler.HandleAsync(@event);


        return true;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}