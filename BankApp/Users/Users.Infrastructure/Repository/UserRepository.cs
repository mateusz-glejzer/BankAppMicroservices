using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Users.Core.Entities;
using Users.Core.Exceptions;
using Users.Core.Repositories;
using Users.Infrastructure.Entities;
using AccountState = Users.Core.Entities.AccountState;

namespace Users.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(UserDbContext context, IServiceProvider serviceProvider, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<User> GetUser(Guid userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        var mappedUser = _mapper.Map<User>(user);
        return mappedUser;
    }

    public async Task<List<User>> GetUsers()
    {
        var usersEntities = await _context.Users.ToListAsync();
        var users = _mapper.Map<List<User>>(usersEntities);
        return users;
    }

    public async Task AddUser(User user)
    {
        var mappedUser = _mapper.Map<UserEntity>(user);
        mappedUser.Id = new Guid();
        await _context.Users.AddAsync(mappedUser);
        await _context.SaveChangesAsync();
    }

    public Task ChangeUser(User user)
    {
        //TODO changing logic is missing
        var userInDb = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        if (userInDb is null)
            throw new UserNotFoundException(user.Id);

        _context.Update(user);
        _context.SaveChanges();
        return Task.CompletedTask;
    }
    
    public Task AddAccountToUser(Guid accountId, Guid userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user is null)
            throw new UserNotFoundException(userId);
        _context.UserAccounts.Add(new UserAccount()
        {
            UserEntity = user,
            AccountNumber = accountId,
            Id = new Guid()
        });
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task ChangeAccountState(Guid accountId, AccountState state)
    {
        throw new NotImplementedException();
    }
    
}