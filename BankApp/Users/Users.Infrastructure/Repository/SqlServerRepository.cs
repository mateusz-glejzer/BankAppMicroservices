﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Users.Core.Entities;
using Users.Core.Exceptions;
using Users.Core.Repositories;
using Users.Infrastructure.Entities;

namespace Users.Api;

public class SqlServerRepository : IUserRepository
{
    private readonly UserDbContext _context;
    //private readonly Mapper _mapper;

    public SqlServerRepository(UserDbContext context)
    {
        _context = context;
      //  _mapper = mapper;
    }

    public async Task<User> GetUser(Guid userId)
    {
        // var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
       // if (user is null)
       // {
       //     throw new UserNotFoundException(userId);
       // }
       //
       // return _mapper.Map<User>(user);
       throw new InvalidOperationException();
    }

    public async Task<List<User>> GetUsers()
    {
        //var usersEntities = await _context.Users.ToListAsync();
        //var users = _mapper.Map<List<User>>(usersEntities);
        //return users;
        throw new InvalidOperationException();
    }

    public async Task AddUser(User user)
    {
        //var mappedUser = _mapper.Map<UserEntity>(user);
        //await _context.Users.AddAsync(mappedUser);
        //await _context.SaveChangesAsync();
        throw new InvalidOperationException();
    }

    public Task ChangeUser(User user)
    {
       // var userInDb = _context.Users.FirstOrDefault(u => u.Id == user.Id);
       // if (user is null)
       //     throw new UserNotFoundException(user.Id);
       // _context.Update(user);
       // _context.SaveChanges();
       // return Task.CompletedTask;
       throw new InvalidOperationException();
    }

    public Task AddAccountToUser(Guid accountId, Guid userId)
    {
      //  var user = _context.Users.FirstOrDefault(u => u.Id == userId);
      //  if (user is null)
      //      throw new UserNotFoundException(userId);
      //
      //  user.Accounts.Add(accountId);
      //  _context.Update(user);
      //  _context.SaveChanges();
      //
      //  return Task.CompletedTask;
      throw new InvalidOperationException();
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