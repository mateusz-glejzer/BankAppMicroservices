using Microsoft.Extensions.DependencyInjection;
using Users.Core.Repositories;
using Users.Infrastructure.Events.External.Handlers;
using Users.Infrastructure.Profiles;
using Users.Infrastructure.Repository;

namespace Users.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {


        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<AccountCreatedHandler>();
        
        return services;
    }
   
}