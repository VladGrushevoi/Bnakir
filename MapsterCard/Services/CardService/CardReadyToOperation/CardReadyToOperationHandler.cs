using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.CardService.CardReadyToOperation;

public sealed class
    CardReadyToOperationHandler : IRequestHandler<CardReadyToOperationRequest, CardReadyToOperationResponse>
{
    private readonly ISystemCard _cardRepository;
    private readonly IMapper _mapper;

    public CardReadyToOperationHandler(ISystemCard cardRepository, IMapper mapper)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;
    }

    public async Task<CardReadyToOperationResponse> Handle(CardReadyToOperationRequest request,
        CancellationToken cancellationToken)
    {
        var cardEntity = _mapper.Map<SystemCard>(request);
        var findCards = await _cardRepository.FindCardsByProperties(cardEntity);

        cardEntity = findCards.FirstOrDefault();
        if (cardEntity == default)
        {
            throw new Exception($"No such elements in database");
        }

        return _mapper.Map<CardReadyToOperationResponse>(cardEntity);
    }
}