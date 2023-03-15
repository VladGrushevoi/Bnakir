using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.Services.CardService.AddCard;

namespace MapsterCard.ServiceProviders;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddCardRequest, SystemCard>();
        CreateMap<SystemCard, AddCardResponse>();
    }
}