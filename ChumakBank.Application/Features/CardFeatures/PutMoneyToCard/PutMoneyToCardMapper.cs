using System.Globalization;
using AutoMapper;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Application.Features.CardFeatures.PutMoneyToCard;

public sealed class PutMoneyToCardMapper : Profile
{
    public PutMoneyToCardMapper()
    {
        CreateMap<MapsterCard, PutMoneyToCardResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Balance, opt
                => opt.MapFrom(src => src.Balance.ToString(CultureInfo.CurrentUICulture)))
            .ForMember(dest => dest.CardId, opt
                => opt.MapFrom(src => src.CardIdFromSystem.ToString()))
            .ForMember(dest => dest.CreatedAt, opt
                => opt.MapFrom(src => src.CreatedAt.ToString()))
            .ForMember(dest => dest.UpdatedAt, opt
                => opt.MapFrom(src => src.UpdatedAt.ToString()));
        CreateMap<KisaCard, PutMoneyToCardResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Balance, opt
                => opt.MapFrom(src => src.Balance.ToString(CultureInfo.CurrentUICulture)))
            .ForMember(dest => dest.CardId, opt
                => opt.MapFrom(src => src.CardIdFromSystem.ToString()))
            .ForMember(dest => dest.CreatedAt, opt
                => opt.MapFrom(src => src.CreatedAt.ToString()))
            .ForMember(dest => dest.UpdatedAt, opt
                => opt.MapFrom(src => src.UpdatedAt.ToString()));
    }
}