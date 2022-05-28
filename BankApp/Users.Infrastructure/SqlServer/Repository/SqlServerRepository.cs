using AutoMapper;
using Users.Core.Entities;
using Users.Core.Exceptions;
using Users.Core.Repositories;
using Users.Infrastructure.SqlServer.Entities;

namespace Users.Infrastructure.SqlServer.Repository;

public class SqlServerRepository : IUserRepository
{
    private readonly UsersDbContext _dbContext;
    private readonly IMapper _mapper;

    public SqlServerRepository(UsersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Create(User user)
    {
        if (await _dbContext.Users.FindAsync(user.Id) is not null)
        {
            throw new UserExistsException(user.Id);
        }

        var newUser = new UserEntity()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };

        await _dbContext.Users.AddAsync(newUser);
    }

    public async Task ChangeAsync(User user)
    {
        var userInDb = await _dbContext.Users.FindAsync(user.Id);
        if (userInDb is null)
        {
            throw new UserNotFoundException(user.Id);
        }

        userInDb.Email = user.Email;
        userInDb.Name = user.Name;
        userInDb.Surname = user.Surname;
        
        _dbContext.Users.Update(userInDb);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var userInDb = await _dbContext.Users.FindAsync(id);
        if (userInDb is null)
        {
            throw new UserNotFoundException(id);
        }

        
        _dbContext.Users.Remove(userInDb);
    }

    public async Task<User> GetAsync(Guid id)
    {
        var userInDb = await _dbContext.Users.FindAsync(id);
        if (userInDb is null)
        {
            throw new UserNotFoundException(id);
        }

        var mappedUser = _mapper.Map<User>(userInDb);
        return mappedUser;
    }
}