using AutoMapper;
using Kisa.Domain.Entities;

namespace Kisa.Application.Features.CardFeatures.CardReadyToOperation;

public sealed class CardReadyToOperationMapper : Profile
{
    public CardReadyToOperationMapper()
    {
        CreateMap<CardReadyToOperationRequest, KisaCard>()
            .ForMember(dest => dest.ExpireTo, opt
                => opt.MapFrom(src => DateOnly.Parse(src.ExpireTo)));
        CreateMap<KisaCard, CardReadyToOperationResponse>()
            .ForMember(dest => dest.IsReady, opt
                => opt.MapFrom(
                    src => src.ExpireTo.HasValue && src.ExpireTo.Value >= DateOnly.FromDateTime(DateTime.Now)));
    }
}