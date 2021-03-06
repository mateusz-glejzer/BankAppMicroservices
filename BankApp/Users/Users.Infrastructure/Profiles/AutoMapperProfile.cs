using AutoMapper;
using Users.Core.Entities;
using Users.Infrastructure.Entities;

namespace Users.Infrastructure.Profiles;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserEntity, User>();
        CreateMap<User, UserEntity>();
    }
}