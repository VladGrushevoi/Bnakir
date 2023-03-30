using System.Globalization;
using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.Services.CardService.AddCard;
using MapsterCard.Services.CardService.CardReadyToOperation;
using MapsterCard.Services.CardService.GetCardById;
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
        CreateMap<SystemCard, AddCardResponse>();
        CreateMap<GetCardByIdRequest, SystemCard>();
        CreateMap<SystemCard, GetCardByIdResponse>();
        CreateMap<CardReadyToOperationRequest, SystemCard>()
            .ForMember(dest => dest.Expire,
                opt
                    => opt.MapFrom(src
                        => DateOnly.Parse(src.Expire)));
        CreateMap<SystemCard, CardReadyToOperationResponse>()
            .ForMember(dest
                => dest.IsReady, opt
                => opt.MapFrom(src
                    => src.Expire.HasValue && (DateOnly.FromDateTime(DateTime.Now) <= src.Expire.Value)));
        CreateMap<SystemCard, TransactionConfirmationResponse>()
            .ForMember(dest => dest.IsConfirm, opt =>
                opt.MapFrom(src => src.Expire.Value >= DateOnly.FromDateTime(DateTime.Now)));
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
                        => src.PercentageOfOperationsInCountry.ToString(CultureInfo.CurrentCulture)));
        CreateMap<MapsterMain, GetPercentageBetweenCountryResponse>()
            .ForMember(dest => dest.PercentageBetweenCountry,
                opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationsBetweenCountry.ToString(CultureInfo.CurrentCulture)));
        CreateMap<MapsterMain, GetPercentageBetweenCardSystemResponse>()
            .ForMember(dest => dest.PercentageBetweenCardSystem,
                opt
                    => opt.MapFrom(src
                        => src.PercentageOfOperationBetweenCardSystem.ToString(CultureInfo.CurrentCulture)));
    }
}