namespace Accounts.Application.Commands.Handlers;

public interface ICommandHandler<in TCommand,T>
    where TCommand : class, ICommand
{
    Task<T> HandleAsync(TCommand command);
}