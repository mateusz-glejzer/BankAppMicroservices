using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using Users.Infrastructure.Events.External;
using Users.Infrastructure.Events.External.Handlers;

namespace Users.Infrastructure;

public class AccountCollector : IHostedService
{
    private readonly ISubscriber _subscriber;

    private readonly ILogger<AccountCollector> _logger;
    private readonly IServiceProvider _serviceProvider;

    public AccountCollector(ISubscriber subscriber, ILogger<AccountCollector> logger, IServiceProvider serviceProvider)
    {
        _subscriber = subscriber;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _subscriber.Subscribe(ProcessMessage);
        _logger.LogInformation("collector is working");
        return Task.CompletedTask;
    }

    private bool ProcessMessage(string message, IDictionary<string, object> headers)
    {
        _logger.LogInformation("message ack");
        var @event = JsonConvert.DeserializeObject<AccountCreated>(message);
        _logger.LogInformation($"{@event.UserId} has new account {@event.BankAccountId}");
        using (var scope = _serviceProvider.CreateScope())
        {
            var accountCreatedHandler = scope.ServiceProvider.GetRequiredService<AccountCreatedHandler>();
            accountCreatedHandler.HandleAsync(@event);
        }


        return true;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}