using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Plain.RabbitMQ;
using Users.Infrastructure.Events.External;
using Users.Infrastructure.Events.External.Handlers;

namespace Users.Infrastructure;

public class AccountCollector : IHostedService
{
    private readonly ISubscriber _subscriber;

    private readonly ILogger<AccountCollector> _logger;
    private readonly IServiceProvider _serviceProvider;

    public AccountCollector(ISubscriber subscriber, ILogger<AccountCollector> logger,IServiceProvider serviceProvider)
    {
        _subscriber = subscriber;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _subscriber.SubscribeAsync(ProcessMessage);
        return Task.CompletedTask;
    }

    private async Task<bool> ProcessMessage(string message, IDictionary<string, object> headers)
    {
        var @event = JsonSerializer.Deserialize<AccountCreated>(message);
        using (var scope = _serviceProvider.CreateScope())
        {
            var transientService = scope.ServiceProvider.GetRequiredService<AccountCreatedHandler>();
            await transientService.HandleAsync(@event);
        }
        _logger.LogInformation($"{@event.UserId} has new account {@event.BankAccountId}");


        return true;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}