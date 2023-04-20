using AutoMapper;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Application.Features.UserFeatures.CreateUserFeature;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>()
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(
                    src => src.Name))
            .ForMember(dest => dest.Surname, 
                opt => opt.MapFrom(
                    src => src.Surname))
            .ForMember(dest => dest.Phone, 
                opt => opt.MapFrom(
                    src => src.Phone))
            .ForMember(dest => dest.Country, 
                opt => opt.MapFrom(
                    src => src.Country));

        CreateMap<User, CreateUserResponse>()
            .ForMember(dest => dest.Id, 
                opt 
                    => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Name, 
                opt 
                    => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Surname, 
                opt 
                    => opt.MapFrom(src => src.Surname))
            .ForMember(dest => dest.Phone, 
                opt 
                    => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Country, 
                opt 
                    => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.CreatedAt, 
                opt 
                    => opt.MapFrom(src => src.CreatedAt.ToString()))
            .ForMember(dest => dest.UpdatedAt, 
                opt 
                    => opt.MapFrom(src => src.CreatedAt != default ? src.UpdatedAt.ToString() : ""));
    }
}