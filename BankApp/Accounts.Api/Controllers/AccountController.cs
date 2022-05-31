using System.Text.Json;
using Accounts.Application;
using Accounts.Application.Commands;
using Accounts.Application.Commands.Handlers;
using Accounts.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Plain.RabbitMQ;

namespace Accounts.Api.Controllers;

public class AccountController : ControllerBase
{
    private readonly IPublisher _publisher;
    private readonly IAccountRepository _repository;
    private readonly CreateAccountHandler _createAccountHandler;

    public AccountController(IPublisher publisher,IAccountRepository repository, CreateAccountHandler createAccountHandler)
    {
        _publisher = publisher;
        _repository = repository;
        _createAccountHandler = createAccountHandler;
    }

    public async Task CreateAccount(Guid userId)
    {
       await _createAccountHandler.HandleAsync(new CreateAccount(userId));
       _publisher.Publish(JsonSerializer.Serialize(new AccountCreated()),"account_exchange",null);
    }
}