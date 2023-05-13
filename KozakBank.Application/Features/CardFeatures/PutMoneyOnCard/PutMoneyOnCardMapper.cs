using System.Globalization;
using AutoMapper;
using KozakBank.Domain.Common;

namespace KozakBank.Application.Features.CardFeatures.PutMoneyOnCard;

public sealed class PutMoneyOnCardMapper : Profile
{
    public PutMoneyOnCardMapper()
    {
        CreateMap<PutMoneyOnCardRequest, BaseCard>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.SysCardId));
        CreateMap<BaseCard, PutMoneyOnCardResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.CardId, opt
                => opt.MapFrom(src => src.IdFromCardSystem.ToString()))
            .ForMember(dest => dest.Balance, opt
                => opt.MapFrom(src => src.Balance.ToString(CultureInfo.CurrentUICulture)))
            .ForMember(dest => dest.CreatedAt, opt
                => opt.MapFrom(src => src.CreatedOnly.ToString()))
            .ForMember(dest => dest.UpdatedAt, opt
                => opt.MapFrom(src => src.UpdatedAt.ToString()));
    }
}