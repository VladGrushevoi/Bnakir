using System.Globalization;
using AutoMapper;
using KozakBank.Domain.Entities;

namespace KozakBank.Application.Features.KozakInfoFeatures.CreateKozakInfo;

public sealed class CreateKozakInfoMapper : Profile
{
    public CreateKozakInfoMapper()
    {
        CreateMap<CreateKozakInfoRequest, KozakInfo>();
        CreateMap<KozakInfo, CreateKozakInfoResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Balance, opt
                => opt.MapFrom(src => src.Balance.ToString(CultureInfo.CurrentUICulture)))
            .ForMember(dest => dest.CommissionValue, opt
                => opt.MapFrom(src => src.CommissionValue.ToString(CultureInfo.CurrentUICulture)))
            .ForMember(dest => dest.BankIdenrifier, opt
                => opt.MapFrom(src => src.BankIdentifier))
            .ForMember(dest => dest.CreatedAt, opt
                => opt.MapFrom(src => src.CreatedOnly.ToString()))
            .ForMember(dest => dest.UpdatedAt, opt
                => opt.MapFrom(src => src.UpdatedAt.ToString()));
    }
}