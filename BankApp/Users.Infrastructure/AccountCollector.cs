using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Plain.RabbitMQ;
using Users.Infrastructure.Events.External;
using Users.Infrastructure.Events.External.Handlers;

namespace Users.Infrastructure;

public class AccountCollector : IHostedService
{
    private readonly ISubscriber _subscriber;
    private readonly AccountCreatedHandler _accountCreatedHandler;

    public AccountCollector(ISubscriber subscriber, AccountCreatedHandler accountCreatedHandler)
    {
        _subscriber = subscriber;
        _accountCreatedHandler = accountCreatedHandler;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _subscriber.SubscribeAsync(ProcessMessage);
        return Task.CompletedTask;
    }

    private async Task<bool> ProcessMessage(string message, IDictionary<string, object> headers)
    {
        if (message.Contains("Account"))
        {
            var @event = JsonSerializer.Deserialize<AccountCreated>(message);
            await _accountCreatedHandler.HandleAsync(@event);
        }

        return true;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}