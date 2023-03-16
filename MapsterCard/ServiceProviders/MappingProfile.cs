using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.Services.CardService.AddCard;
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
    }
}