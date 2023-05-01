using System.Globalization;
using AutoMapper;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Application.Features.ChumakInfoFeatures.CreateChumakFeature;

public sealed class CreateChumakMapper : Profile
{
    public CreateChumakMapper()
    {
        CreateMap<CreateChumakRequest, ChumakInfo>()
            .ForMember(dest => dest.CommissionForOperation, opt 
            => opt.MapFrom(src => src.CommissionOfOperation))
            .ForMember(dest => dest.Balance, opt 
            => opt.MapFrom(src => src.Balance));

        CreateMap<ChumakInfo, CreateChumakResponse>()
            .ForMember(dest => dest.Id, opt 
            => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Balance, opt 
                => opt.MapFrom(src => src.Balance.ToString(CultureInfo.InvariantCulture)))
            .ForMember(dest => dest.Commission, opt 
                => opt.MapFrom(src => src.CommissionForOperation.ToString(CultureInfo.InvariantCulture)))
            .ForMember(dest => dest.BankIdentifier, opt 
            => opt.MapFrom(src => src.BankIdentifier))
            .ForMember(dest => dest.CreatedAt, opt 
                => opt.MapFrom(src => src.CreatedAt.ToString()))
            .ForMember(dest => dest.UpdatedAt, opt 
                => opt.MapFrom(src => src.UpdatedAt.ToString()));
    }
}