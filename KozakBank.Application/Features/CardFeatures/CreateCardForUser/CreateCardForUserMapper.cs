using AutoMapper;
using KozakBank.Application.Common.UseCardSystem.Models.Response;
using KozakBank.Domain.Entities;

namespace KozakBank.Application.Features.CardFeatures.CreateCardForUser;

public class CreateCardForUserMapper : Profile
{
    public CreateCardForUserMapper()
    {
        CreateMap<CreateCardForUserRequest, User>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.UserId));
        CreateMap<CreateCardResponse, KisaCard>()
            .ForMember(dest => dest.IdFromCardSystem, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Balance, opt
                => opt.MapFrom(_ => 0f));
        CreateMap<CreateCardResponse, MapsterCard>()
            .ForMember(dest => dest.IdFromCardSystem, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Balance, opt
                => opt.MapFrom(_ => 0f));
        CreateMap<KisaCard, CreateCardForUserResponse>()
            .ForMember(dest => dest.IdFromSysCard, opt
            => opt.MapFrom(src => src.IdFromCardSystem))
            .ForMember(dest => dest.CreatedAt, opt 
            => opt.MapFrom(src => src.CreatedOnly.ToString()));
        CreateMap<MapsterCard, CreateCardForUserResponse>()
            .ForMember(dest => dest.IdFromSysCard, opt
                => opt.MapFrom(src => src.IdFromCardSystem))
            .ForMember(dest => dest.CreatedAt, opt 
                => opt.MapFrom(src => src.CreatedOnly.ToString()));
    }
}