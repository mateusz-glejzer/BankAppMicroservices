using Users.Core.Entities;

namespace Users.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetUser(Guid userId);
    Task<List<User>> GetUsers();
    Task AddUser(User user);
    Task ChangeUser(User user);
    Task AddAccountToUser(Guid accountId, Guid userId);
    Task ChangeAccountState(Guid accountId, AccountState state);
}