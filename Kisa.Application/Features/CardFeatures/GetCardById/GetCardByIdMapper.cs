using AutoMapper;
using Kisa.Application.Features.CardFeatures.CreateCard;
using Kisa.Domain.Entities;

namespace Kisa.Application.Features.CardFeatures.GetCardById;

public sealed class GetCardByIdMapper : Profile
{
    public GetCardByIdMapper()
    {
        CreateMap<GetCardByIdRequest, KisaCard>();
        CreateMap<KisaCard, GetCardByIdResponse>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src 
                    => src.Id.ToString()))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src 
                    => src.CreatedAt.Value.ToString()))
            .ForMember(dest => dest.ExpireTo,
                opt => opt.MapFrom(src 
                    => src.ExpireTo.Value.ToString()));
    }
}