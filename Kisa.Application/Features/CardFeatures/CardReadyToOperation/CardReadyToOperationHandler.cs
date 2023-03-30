using AutoMapper;
using Kisa.Application.Common.Exception;
using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using MediatR;

namespace Kisa.Application.Features.CardFeatures.CardReadyToOperation;

public sealed class
    CardReadyToOperationHandler : IRequestHandler<CardReadyToOperationRequest, CardReadyToOperationResponse>
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;

    public CardReadyToOperationHandler(IMapper mapper, ICardRepository cardRepository)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
    }

    public async Task<CardReadyToOperationResponse> Handle(CardReadyToOperationRequest request,
        CancellationToken cancellationToken)
    {
        var cardEntity = _mapper.Map<KisaCard>(request);

        var result = await _cardRepository.FindCardsByProperties(cardEntity, cancellationToken);
        if (!result.Any())
        {
            throw new NotFoundException("Not found cards");
        }

        var findCard = result.First();

        return _mapper.Map<CardReadyToOperationResponse>(findCard);
    }
}