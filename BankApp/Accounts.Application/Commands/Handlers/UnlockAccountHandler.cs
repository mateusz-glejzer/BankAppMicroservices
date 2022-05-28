using Accounts.Domain.Repositories;

namespace Accounts.Application.Commands.Handlers;

public class UnlockAccountHandler : ICommandHandler<UnlockAccount>
{
    private IAccountRepository _repository;

    public UnlockAccountHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(UnlockAccount command)
    {
        command.BankAccount.IsLocked = false;
        await _repository.ChangeAsync(command.BankAccount);
    }
}