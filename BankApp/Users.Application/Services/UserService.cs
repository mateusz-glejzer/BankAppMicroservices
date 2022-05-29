using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Users.Core.Entities;
using Users.Core.Exceptions;
using Users.Infrastructure.Mongo.Entities;

namespace Users.Application.Services;

public class UserService : IUserService
{
    private readonly UserDbContext _context;
    private readonly Mapper _mapper;

    public UserService(UserDbContext context, Mapper mapper)
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

        return _mapper.Map<User>(user);
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
        await _context.Users.AddAsync(mappedUser);
        await _context.SaveChangesAsync();
    }

    public Task ChangeUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task AddAccountToUser(Guid accountId, Guid userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user is null)
            throw new UserNotFoundException(userId);

        user.Accounts.Add(accountId);
        _context.Update(user);
        _context.SaveChanges();

        return Task.CompletedTask;
    }

    public async Task Populate()
    {
        for (int i = 0; i < 20; i++)
        {
            var newUser = new User($"john{i}", $"johnsky{i}", $"email{i}");
            await AddUser(newUser);
        }
    }
}