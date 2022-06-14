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
    private readonly GetUserAccountsHandler _getUserAccountsHandler;

    public AccountController(CreateAccountHandler createAccountHandler, GetAccountHandler getAccountHandler,
        GetUserAccountsHandler getUserAccountsHandler)
    {
        _createAccountHandler = createAccountHandler;
        _getAccountHandler = getAccountHandler;
        _getUserAccountsHandler = getUserAccountsHandler;
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

    [HttpGet]
    [Route("/api/getUserAccounts")]
    public async Task<IEnumerable<Guid>> GetUserAccounts([FromBody] Guid id)
    {
        return await _getUserAccountsHandler.HandleAsync(new GetUserAccounts(id));
    }
}