using System.Globalization;
using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.Services.CardService.AddCard;
using MapsterCard.Services.CardService.CardReadyToOperation;
using MapsterCard.Services.CardService.GetCardById;
using MapsterCard.Services.CardService.GetCardByProperties;
using MapsterCard.Services.SystemService.AddSystemSettings;
using MapsterCard.Services.SystemService.GetPercentage;
using MapsterCard.Services.SystemService.TransactionConfirmation;
using MapsterCard.Services.SystemService.UpdatePercentage;

namespace MapsterCard.ServiceProviders;

public sealed class CardMappingProfile : Profile
{
    public CardMappingProfile()
    {
        CreateMap<AddCardRequest, SystemCard>();
        CreateMap<SystemCard, AddCardResponse>()
            .ForMember(dest => dest.ShortExpireTo, opt
                => opt.MapFrom(src => src.ShortExpireTo));
        CreateMap<GetCardByIdRequest, SystemCard>();
        CreateMap<SystemCard, GetCardByIdResponse>();
        CreateMap<CardReadyToOperationRequest, SystemCard>()
            .ForMember(dest => dest.ShortExpireTo,
                opt
                    => opt.MapFrom(src
                        => src.ShortExpireTo));
        CreateMap<SystemCard, CardReadyToOperationResponse>()
            .ForMember(dest
                => dest.IsReady, opt
                => opt.MapFrom(src
                    => src.ExpireTo.HasValue && (DateOnly.FromDateTime(DateTime.Now) <= src.ExpireTo.Value)));
        CreateMap<SystemCard, TransactionConfirmationResponse>()
            .ForMember(dest => dest.IsConfirm, opt =>
                opt.MapFrom(src => src.ExpireTo.Value >= DateOnly.FromDateTime(DateTime.Now)));
        CreateMap<GetCardByPropertiesRequest, SystemCard>()
            .ForMember(dest => dest.ExpireTo, opt
                => opt.MapFrom(src => DateOnly.Parse(src.ExpireTo)))
            .ForMember(dest => dest.CreatedAt, opt
                => opt.MapFrom(src => DateOnly.Parse(src.CreatedAt)))
            .ForMember(dest => dest.ShortExpireTo, opt
                => opt.MapFrom(src => src.ShortExpireTo));
        CreateMap<SystemCard, GetCardByPropertiesResponse>()
            .ForMember(dest => dest.ExpireTo, opt
                => opt.MapFrom(src => src.ExpireTo!.Value.ToString()))
            .ForMember(dest => dest.CreatedAt, opt
                => opt.MapFrom(src => src.CreatedAt!.Value.ToString()))
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.ShortExpireTo, opt
                => opt.MapFrom(src => src.ShortExpireTo));
    }
}

public sealed class SystemMappingProfile : Profile
{
    public SystemMappingProfile()
    {
        CreateMap<AddSystemSettingsRequest, MapsterMain>();
        CreateMap<MapsterMain, AddSystemSettingsResponse>()
            .ForMember(dest
                    => dest.PercentageBetweenCountry,
                opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationsBetweenCountry.ToString(CultureInfo.CurrentCulture)))
            .ForMember(dest
                    => dest.PercentageInCountry,
                opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationsInCountry.ToString(CultureInfo.CurrentCulture)))
            .ForMember(dest
                    => dest.PercentageBetweenCardSystem,
                opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationBetweenCardSystem.ToString(CultureInfo.CurrentCulture)));
        CreateMap<UpdatePercentageRequest, MapsterMain>()
            .ForMember(dest => dest.PercentageOfOperationsInCountry,
                opt
                    => opt.MapFrom(src => src.PercentageInCountry))
            .ForMember(dest => dest.PercentageOfOperationsBetweenCountry,
                opt
                    => opt.MapFrom(src => src.PercentageBetweenCountry))
            .ForMember(dest => dest.PercentageOfOperationBetweenCardSystem,
                opt
                    => opt.MapFrom(src => src.PercentageBetweenCardSystem));
        CreateMap<MapsterMain, UpdatePercentageResponse>()
            .ForMember(dest
                    => dest.PercentageBetweenCountry, opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationsBetweenCountry.ToString(CultureInfo.CurrentCulture)
                    )
            )
            .ForMember(dest
                    => dest.PercentageInCountry, opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationsInCountry.ToString(CultureInfo.CurrentCulture)
                    )
            )
            .ForMember(dest
                    => dest.PercentageBetweenCardSystem, opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationBetweenCardSystem.ToString(CultureInfo.CurrentCulture)
                    )
            );
        CreateMap<MapsterMain, GetPercentageInCountryResponse>()
            .ForMember(dest => dest.PercentageInCountry,
                opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationsInCountry));
        CreateMap<MapsterMain, GetPercentageBetweenCountryResponse>()
            .ForMember(dest => dest.PercentageBetweenCountry,
                opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationsBetweenCountry));
        CreateMap<MapsterMain, GetPercentageBetweenCardSystemResponse>()
            .ForMember(dest => dest.PercentageBetweenCardSystem,
                opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationBetweenCardSystem));
    }
}