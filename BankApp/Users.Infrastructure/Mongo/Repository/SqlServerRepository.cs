using Users.Core.Entities;
using Users.Core.Repositories;

namespace Users.Infrastructure.Mongo.Repository;

public class SqlServerRepository: IUserRepository
{
    public Task Create(User user)
    {
        throw new NotImplementedException();
    }

    public Task ChangeAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}