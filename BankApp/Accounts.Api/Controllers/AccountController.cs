using System.Numerics;
using Accounts.Application.Commands;
using Accounts.Application.Commands.Handlers;
using Accounts.Application.Queries;
using Accounts.Domain.Repositories;
using Accounts.Infrastructure.Handlers;
using Microsoft.AspNetCore.Mvc;
using Plain.RabbitMQ;

namespace Accounts.Api.Controllers;

public class AccountController : ControllerBase
{
    private readonly IPublisher _publisher;
    private readonly IAccountRepository _repository;
    private readonly CreateAccountHandler _createAccountHandler;
    private readonly GetAccountsHandler _getAccountsHandler;
    private readonly ChangeBalanceHandler _changeBalanceHandler;
    private readonly GetAccountHandler _getAccountHandler;

    public AccountController(IPublisher publisher, IAccountRepository repository,
        CreateAccountHandler createAccountHandler, GetAccountHandler getAccountHandler,
        GetAccountsHandler getAccountsHandler, ChangeBalanceHandler changeBalanceHandler)
    {
        _publisher = publisher;
        _repository = repository;
        _createAccountHandler = createAccountHandler;
        _getAccountsHandler = getAccountsHandler;
        _changeBalanceHandler = changeBalanceHandler;
        _getAccountHandler = getAccountHandler;
    }

    [HttpPost]
    [Route("/api/add")]
    public async Task CreateAccount(Guid userId)
    {
        await _createAccountHandler.HandleAsync(new CreateAccount(userId));
    }

    [HttpGet]
    [Route("/api/getAccount/{id:guid}")]
    public async Task GetAccount(Guid id)
    {
        await _getAccountHandler.HandleAsync(new GetAccount(id));
    }

    [HttpGet]
    [Route("/api/getAccounts/{id:guid}")]
    public async Task GetAccounts(Guid id)
    {
        await _getAccountsHandler.HandleAsync(new GetAccounts(id));
    }

    [HttpPost]
    [Route("/api/changeBalance/{amount}")]
    public async Task ChangeBalance(Guid accountNumber, BigInteger amount)
    {
        await _changeBalanceHandler.HandleAsync(new ChangeBalance(accountNumber, amount));
    }
}