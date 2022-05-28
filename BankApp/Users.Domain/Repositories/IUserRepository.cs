using Users.Core.Entities;

namespace Users.Core.Repositories;

public interface IUserRepository
{
    Task Create(User user);
    Task ChangeAsync(User user);
    Task DeleteAsync(Guid id);
    Task<User> GetAsync(Guid id);
}