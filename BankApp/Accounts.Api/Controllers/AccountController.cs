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

    [HttpPost]
    [Route("/api/add")]

        public async Task CreateAccount(Guid userId)
    {
       await _createAccountHandler.HandleAsync(new CreateAccount(userId));
       
    }
}