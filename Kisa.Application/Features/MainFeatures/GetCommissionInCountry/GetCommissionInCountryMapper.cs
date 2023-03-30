using AutoMapper;
using Kisa.Domain.Entities;

namespace Kisa.Application.Features.MainFeatures.GetCommissionInCountry;

public sealed class GetCommissionInCountryMapper : Profile
{
    public GetCommissionInCountryMapper()
    {
        CreateMap<KisaMain, GetCommissionInCountryResponse>()
            .ForMember(dest => dest.CommissionInCountry, opt
                => opt.MapFrom(src => src.CommissionInCountry));
    }
}