using AutoMapper;
using Kisa.Application.Common.Exception;
using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using MediatR;

namespace Kisa.Application.Features.CardFeatures.GetCardByProperties;

public sealed class GetCardByPropertiesHandler : IRequestHandler<GetCardByPropertiesRequest, GetCardByPropertiesResponse>
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;

    public GetCardByPropertiesHandler(ICardRepository cardRepository, IMapper mapper)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;
    }

    public async Task<GetCardByPropertiesResponse> Handle(GetCardByPropertiesRequest request, CancellationToken cancellationToken)
    {
        var cardEntity = _mapper.Map<KisaCard>(request);

        var cards = await _cardRepository.FindCardsByProperties(cardEntity, cancellationToken);
        if (!cards.Any())
        {
            throw new BadRequestException($"Card not founded {request}");
        }

        var findCard = cards.First();

        return _mapper.Map<GetCardByPropertiesResponse>(findCard);
    }
}