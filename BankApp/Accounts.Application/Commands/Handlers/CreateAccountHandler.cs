using IAccountRepository = Accounts.Domain.Repositories.IAccountRepository;

namespace Accounts.Application.Commands.Handlers;

public class CreateAccountHandler : ICommandHandler<CreateAccount>
{
    private readonly IAccountRepository _repository;

    public CreateAccountHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateAccount command)
    {
        await _repository.AddAsync(command.Account);
    }
}