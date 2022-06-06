using Accounts.Application.Commands;
using Accounts.Application.Commands.Handlers;
using Accounts.Application.Queries;
using Accounts.Domain.Entities;
using Accounts.Domain.Repositories;
using Accounts.Infrastructure.Handlers;
using Accounts.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Accounts.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddCommandHandler<CreateAccount, CreateAccountHandler>();
        services.AddCommandHandler<ChangeAccountState, ChangeAccountStateHandler>();
        services.AddCommandHandler<ChangeBalance, ChangeBalanceHandler>();
        services.AddQueryHandler<GetAccount,Account,GetAccountHandler>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        return services;
    }

    private static IServiceCollection AddCommandHandler<TCommand, TCommandHandler>(
        this IServiceCollection services
    )
        where TCommandHandler : class, ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        return services.AddTransient<TCommandHandler>()
            .AddTransient<ICommandHandler<TCommand>>(sp => sp.GetRequiredService<TCommandHandler>());
    }

    private static IServiceCollection AddQueryHandler<TQuery, TQueryResult, TQueryHandler>(
        this IServiceCollection services
    )
        where TQueryHandler : class, IQueryHandler<TQuery, TQueryResult> where TQuery : class, IQuery<TQueryResult>
    {
        return services.AddTransient<TQueryHandler>()
            .AddTransient<IQueryHandler<TQuery, TQueryResult>>(sp => sp.GetRequiredService<TQueryHandler>());
    }
}