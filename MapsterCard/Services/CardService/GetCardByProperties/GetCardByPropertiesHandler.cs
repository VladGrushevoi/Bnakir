using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.CardService.GetCardByProperties;

public sealed class GetCardByPropertiesHandler : IRequestHandler<GetCardByPropertiesRequest, GetCardByPropertiesResponse>
{
    private readonly ISystemCard _systemCard;
    private readonly IMapper _mapper;

    public GetCardByPropertiesHandler(ISystemCard systemCard, IMapper mapper)
    {
        _systemCard = systemCard;
        _mapper = mapper;
    }

    public async Task<GetCardByPropertiesResponse> Handle(GetCardByPropertiesRequest request, CancellationToken cancellationToken)
    {
        var cardEntity = _mapper.Map<SystemCard>(request);

        var cards = await _systemCard.FindCardsByProperties(cardEntity);
        if (!cards.Any())
        {
            throw new Exception("No such elements");
        }

        var findCard = cards.First();

        return _mapper.Map<GetCardByPropertiesResponse>(findCard);
    }
}