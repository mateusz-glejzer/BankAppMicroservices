using Accounts.Domain.Entities;
using Accounts.Domain.Repositories;

namespace Accounts.Application.Commands.Handlers;

public class ChangeBalanceHandler : ICommandHandler<ChangeBalance>
{
    private readonly IAccountRepository _repository;

    public ChangeBalanceHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(ChangeBalance command)
    {
        var account = await _repository.GetAsync(command.BankAccount);
        if (account.State is not AccountState.Active)
        {
            throw new Exception("Balance can't be changed, account status is locked or disabled");
        }

        account.Balance += command.Amount;
        if (account.Balance < 0)
            account.State = AccountState.Locked;
        await _repository.ChangeAsync(account);
    }
}