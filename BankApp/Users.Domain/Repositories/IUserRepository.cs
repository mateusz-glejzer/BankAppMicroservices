using Users.Core.Entities;

namespace Users.Core.Repositories;

public interface IUserRepository
{
    Task Create(User user);
    Task ChangeAsync(User user);
    Task DeleteAsync(User user);
    Task GetAsync(User user);
}