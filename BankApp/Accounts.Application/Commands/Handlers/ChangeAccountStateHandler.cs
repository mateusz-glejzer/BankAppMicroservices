using Accounts.Domain.Repositories;

namespace Accounts.Application.Commands.Handlers;

public class ChangeAccountStateHandler : ICommandHandler<ChangeAccountState>
{
    private readonly IAccountRepository _repository;

    public ChangeAccountStateHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(ChangeAccountState command)
    {
        var bankAccount = await _repository.GetAsync(command.BankAccount);
        bankAccount.State = command.State;
        await _repository.ChangeAsync(bankAccount);
    }
}