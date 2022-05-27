using Microsoft.Extensions.DependencyInjection;

namespace Accounts.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, string dbConnectionString)
    {
        return services;
    }
}