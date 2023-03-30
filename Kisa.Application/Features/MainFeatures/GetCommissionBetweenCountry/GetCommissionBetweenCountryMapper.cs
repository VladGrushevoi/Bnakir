using AutoMapper;
using Kisa.Domain.Entities;

namespace Kisa.Application.Features.MainFeatures.GetCommissionBetweenCountry;

public sealed class GetCommissionBetweenCountryMapper : Profile
{
    public GetCommissionBetweenCountryMapper()
    {
        CreateMap<KisaMain, GetCommissionBetweenCountryResponse>()
            .ForMember(dest => dest.CommissionBetweenCountry, opt
                => opt.MapFrom(src => src.CommissionBetweenCountry));
    }
}