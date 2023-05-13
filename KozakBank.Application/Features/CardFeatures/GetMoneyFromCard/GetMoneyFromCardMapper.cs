using AutoMapper;
using KozakBank.Domain.Entities;

namespace KozakBank.Application.Features.CardFeatures.GetMoneyFromCard;

public sealed class GetMoneyFromCardMapper : Profile
{
    public GetMoneyFromCardMapper()
    {
        CreateMap<GetMoneyFromCardRequest, KisaCard>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.SysCardId));
        
        CreateMap<GetMoneyFromCardRequest, MapsterCard>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.SysCardId));
    }
}