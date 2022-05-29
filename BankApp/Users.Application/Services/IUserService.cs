using Users.Core.Entities;

namespace Users.Application.Services;

public interface IUserService
{
    Task<User> GetUser(Guid userId);
    Task<List<User>> GetUsers();
    Task AddUser(User user);
    Task ChangeUser(User user);
    Task AddAccountToUser(Guid accountId, Guid userId);
}