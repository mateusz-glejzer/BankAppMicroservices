﻿namespace Accounts.Core.Commands.Handlers;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command);
}