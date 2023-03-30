using AutoMapper;
using Kisa.Domain.Entities;

namespace Kisa.Application.Features.MainFeatures.GetCommissionBetweenCardSystems;

public sealed class GetCommissionBetweenCardSystemsMapper : Profile
{
    public GetCommissionBetweenCardSystemsMapper()
    {
        CreateMap<KisaMain, GetCommissionBetweenCardSystemsResponse>()
            .ForMember(dest => dest.CommissionBetweenCardSystems, opt
                => opt.MapFrom(src => src.CommissionBetweenCardSystem));
    }
}