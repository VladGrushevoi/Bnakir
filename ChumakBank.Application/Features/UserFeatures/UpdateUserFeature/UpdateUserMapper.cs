using AutoMapper;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Application.Features.UserFeatures.UpdateUserFeature;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserRequest, User>()
            .ForMember(dest => dest.Id, opt => 
                opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => 
                opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Surname, opt => 
                opt.MapFrom(src => src.Surname))
            .ForMember(dest => dest.Phone, opt => 
                opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Country, opt => 
                opt.MapFrom(src => src.Country));

        CreateMap<User, UpdateUserResponse>()
            .ForMember(dest => dest.Id, opt => 
                opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.CreatedAt, opt => 
                opt.MapFrom(src => src.CreatedAt.ToString()))
            .ForMember(dest => dest.UpdatedAt, opt => 
                opt.MapFrom(src => src.UpdatedAt.ToString()));

        CreateMap<User, User>()
            .ForMember(dest => dest.CreatedAt, opt => 
                opt.MapFrom((src, dest) => src.CreatedAt != default ? src.CreatedAt : dest.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => 
                opt.MapFrom((src, dest) => src.UpdatedAt != default ? src.UpdatedAt : dest.UpdatedAt));
    }
}