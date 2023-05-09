using AutoMapper;
using KozakBank.Domain.Entities;

namespace KozakBank.Application.Features.UserFeatures.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>()
            .ForMember(dest => dest.Id, opt 
            => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.CreatedAt, opt 
            => opt.MapFrom(src => src.CreatedOnly.ToString()))
            .ForMember(dest => dest.UpdatedAt, opt 
            => opt.MapFrom(src => src.UpdatedAt.ToString()));
    }
}