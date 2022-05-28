using Transactions.Domain;

namespace Transactions.Application.Commands.Handlers;

public class CreateTransactionHandler : ICommandHandler<CreateTransaction>
{
    private readonly ITransactionRepository _repository;

    public CreateTransactionHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateTransaction command)
    {
        await _repository.Create(command.Transaction);
    }
}