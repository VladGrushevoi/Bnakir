using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.Services.CardService.AddCard;
using MapsterCard.Services.CardService.CardReadyToOperation;
using MapsterCard.Services.CardService.GetCardById;

namespace MapsterCard.ServiceProviders;

public class MappingProfile : Profile
{
    public MappingProfile()
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
    }
}