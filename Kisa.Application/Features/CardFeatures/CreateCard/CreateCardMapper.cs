using System.Globalization;
using AutoMapper;
using Kisa.Domain.Entities;

namespace Kisa.Application.Features.CardFeatures.CreateCard;

public sealed class CreateCardMapper : Profile
{
    public CreateCardMapper()
    {
        CreateMap<CreateCardRequest, KisaCard>();
        CreateMap<KisaCard, CreateCardResponse>()
            .ForMember(dest => dest.CreatedAt, opt 
                => opt.MapFrom(src => src.CreatedAt.Value.ToString(CultureInfo.CurrentCulture)))
            .ForMember(dest => dest.ExpireTo, opt 
                => opt.MapFrom(src => src.ExpireTo.Value.ToString(CultureInfo.CurrentCulture)));
    }
}