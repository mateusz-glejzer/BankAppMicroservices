using System.Numerics;
using Accounts.Application.Commands;
using Accounts.Application.Commands.Handlers;
using Accounts.Application.Queries;
using Accounts.Domain.Entities;
using Accounts.Infrastructure.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Api.Controllers;

public class AccountController : ControllerBase
{
    private readonly CreateAccountHandler _createAccountHandler;
    private readonly GetAccountsHandler _getAccountsHandler;
    private readonly ChangeBalanceHandler _changeBalanceHandler;
    private readonly GetAccountHandler _getAccountHandler;

    public AccountController(CreateAccountHandler createAccountHandler, GetAccountHandler getAccountHandler,
        GetAccountsHandler getAccountsHandler, ChangeBalanceHandler changeBalanceHandler)
    {
        _createAccountHandler = createAccountHandler;
        _getAccountsHandler = getAccountsHandler;
        _changeBalanceHandler = changeBalanceHandler;
        _getAccountHandler = getAccountHandler;
    }

    [HttpPost]
    [Route("/api/addAccount")]
    public async Task CreateAccount([FromForm]Guid userId, [FromForm]Currency currency)
    {
        await _createAccountHandler.HandleAsync(new CreateAccount(userId, currency));
    }

    [HttpGet]
    [Route("/api/getAccount")]
    public async Task GetAccount([FromForm]Guid id)
    {
        await _getAccountHandler.HandleAsync(new GetAccount(id));
    }

    [HttpGet]
    [Route("/api/getAccounts")]
    public async Task GetAccounts([FromForm]Guid id)
    {
        await _getAccountsHandler.HandleAsync(new GetAccounts(id));
    }

    [HttpPost]
    [Route("/api/changeBalance")]
    public async Task ChangeBalance([FromForm]Guid accountNumber, [FromForm]BigInteger amount)
    {
        await _changeBalanceHandler.HandleAsync(new ChangeBalance(accountNumber, amount));
    }
}