using AutoMapper;
using ChumakBank.Application.Common.CardSystemsCallerApi;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Application.Features.UserFeatures.CreateCardForUserFeature;

public sealed class CreateCardForUserMapper : Profile
{
    public CreateCardForUserMapper()
    {
        CreateMap<CreateCardForUserRequest, User>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => Guid.Parse(src.UserId)));

        CreateMap<KisaCard, CreateCardForUserResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id.ToString()));

        CreateMap<MapsterCard, CreateCardForUserResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id.ToString()));

        CreateMap<CreateCardResponse, KisaCard>()
            .ForMember(dest => dest.Balance, opt
                => opt.MapFrom(_ => 0f))
            .ForMember(dest => dest.CardIdFromSystem, opt
                => opt.MapFrom(src => src.Id.ToString()));
        CreateMap<CreateCardResponse, MapsterCard>()
            .ForMember(dest => dest.Balance, opt
                => opt.MapFrom(_ => 0))
            .ForMember(dest => dest.CardIdFromSystem, opt
                => opt.MapFrom(src => src.Id.ToString()));
    }
}