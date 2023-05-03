using AutoMapper;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Application.Features.CardFeatures.GetMoneyFromCard;

public class GetMoneyFromCardMapper : Profile
{
    public GetMoneyFromCardMapper()
    {
        CreateMap<GetMoneyFromCardRequest, KisaCard>()
            .ForMember(dest => dest.CardIdFromSystem, opt
            => opt.MapFrom(src => Guid.Parse(src.IdFromCardSystem)));
        
        CreateMap<GetMoneyFromCardRequest, MapsterCard>()
            .ForMember(dest => dest.CardIdFromSystem, opt
                => opt.MapFrom(src => Guid.Parse(src.IdFromCardSystem)));
    }
}