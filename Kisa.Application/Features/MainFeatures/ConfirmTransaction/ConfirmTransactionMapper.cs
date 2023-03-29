using AutoMapper;
using Kisa.Domain.Entities;

namespace Kisa.Application.Features.MainFeatures.ConfirmTransaction;

public class ConfirmTransactionMapper : Profile
{
    public ConfirmTransactionMapper()
    {
        CreateMap<ConfirmTransactionRequest, KisaCard>()
            .ForMember(dest => dest.CardNumber, opt
                => opt.MapFrom(src => src.Card.CardNumber))
            .ForMember(dest => dest.CVV, opt
                => opt.MapFrom(src => src.Card.CVV))
            .ForMember(dest => dest.ExpireTo, opt
                => opt.MapFrom(src => DateOnly.Parse(src.Card.ExpireTo)));
        CreateMap<KisaCard, ConfirmTransactionResponse>()
            .ForMember(dest => dest.IsTransactionConfirmed, opt
                => opt.MapFrom(src => src.ExpireTo.HasValue && src.ExpireTo >= DateOnly.FromDateTime(DateTime.Now)));
    }
}