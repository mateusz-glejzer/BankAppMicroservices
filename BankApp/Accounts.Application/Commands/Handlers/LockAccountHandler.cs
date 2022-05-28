using Accounts.Domain.Repositories;

namespace Accounts.Application.Commands.Handlers;

public class LockAccountHandler:ICommandHandler<LockAccount>
{
    private readonly IAccountRepository _repository;

    public LockAccountHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(LockAccount command)
    {
        command.BankAccount.IsLocked = true;
        await _repository.ChangeAsync(command.BankAccount);
    }
}