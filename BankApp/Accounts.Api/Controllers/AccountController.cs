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
    private readonly GetAccountHandler _getAccountHandler;

    public AccountController(CreateAccountHandler createAccountHandler, GetAccountHandler getAccountHandler)
    {
        _createAccountHandler = createAccountHandler;
        _getAccountHandler = getAccountHandler;
    }

    [HttpPost]
    [Route("/api/addAccount")]
    public async Task<string> CreateAccount([FromBody] Guid userId, [FromBody] Currency currency)
    {
        var result = await _createAccountHandler.HandleAsync(new CreateAccount(userId, currency));
        return result == Guid.Empty ? "Error: Account didn't created" : $"Account created {result}";
    }

    [HttpGet]
    [Route("/api/getAccount")]
    public async Task<Account> GetAccount([FromBody] Guid id)
    {
        return await _getAccountHandler.HandleAsync(new GetAccount(id));
    }
}