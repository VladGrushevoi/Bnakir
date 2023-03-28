using System.Globalization;
using AutoMapper;
using Kisa.Domain.Entities;

namespace Kisa.Application.Features.MainFeatures.UpdateMainSetting;

public sealed class UpdateMainSettingMapper : Profile
{
    public UpdateMainSettingMapper()
    {
        CreateMap<UpdateMainSettingRequest, KisaMain>()
            .ForMember(dest => dest.Id, opt 
            => opt.MapFrom(src => new Guid(src.Id)));
        CreateMap<KisaMain, UpdateMainSettingResponse>()
            .ForMember(dest => dest.Id, opt 
            => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Balance, opt 
                => opt.MapFrom(src => src.Balance.ToString(CultureInfo.CurrentCulture)))
            .ForMember(dest => dest.CommissionInCountry, opt 
                => opt.MapFrom(src => src.CommissionInCountry.ToString(CultureInfo.CurrentCulture)))
            .ForMember(dest => dest.CommissionBetweenCountry, opt 
                => opt.MapFrom(src => src.CommissionBetweenCountry.ToString(CultureInfo.CurrentCulture)))
            .ForMember(dest => dest.CommissionBetweenCardSystem, opt 
                => opt.MapFrom(src => src.CommissionBetweenCardSystem.ToString(CultureInfo.CurrentCulture)));
    }
}