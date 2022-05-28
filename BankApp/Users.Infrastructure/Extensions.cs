using Microsoft.Extensions.DependencyInjection;
using Users.Core.Repositories;
using Users.Infrastructure.SqlServer;
using Users.Infrastructure.SqlServer.Repository;

namespace Users.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbConnectionString)
    {
        services.AddSqlServer<UsersDbContext>(dbConnectionString);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IUserRepository, SqlServerRepository>();

        return services;
    }
}