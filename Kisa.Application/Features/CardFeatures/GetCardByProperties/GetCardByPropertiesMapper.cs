using AutoMapper;
using Kisa.Domain.Entities;

namespace Kisa.Application.Features.CardFeatures.GetCardByProperties;

public sealed class GetCardByPropertiesMapper : Profile
{
    public GetCardByPropertiesMapper()
    {
        CreateMap<GetCardByPropertiesRequest, KisaCard>()
            .ForMember(dest => dest.ExpireTo, opt 
            => opt.MapFrom(src => DateOnly.Parse(src.ExpireTo)))
            .ForMember(dest => dest.CreatedAt, opt 
                => opt.MapFrom(src => DateOnly.Parse(src.CreatedAt)));
        CreateMap<KisaCard, GetCardByPropertiesResponse>()
            .ForMember(dest => dest.ExpireTo, opt 
                => opt.MapFrom(src => src.ExpireTo!.Value.ToString()))
            .ForMember(dest => dest.CreatedAt, opt 
                => opt.MapFrom(src => src.CreatedAt!.Value.ToString()));
    }
}