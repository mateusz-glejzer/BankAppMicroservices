using Accounts.Domain.Entities;
using Accounts.Infrastructure.Dto;
using AutoMapper;

namespace Accounts.Infrastructure;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Account, AccountDto>();
    }
}