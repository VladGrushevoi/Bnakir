using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.CardService.AddCard;

public class AddCardHandler : IRequestHandler<AddCardRequest, AddCardResponse>
{
    private readonly ISystemCard _cardRepository;
    private readonly IMapper _mapper;

    public AddCardHandler(ISystemCard cardRepository, IMapper mapper)
    {
        this._cardRepository = cardRepository;
        _mapper = mapper;
    }

    public async Task<AddCardResponse> Handle(AddCardRequest request, CancellationToken cancellationToken)
    {
        var rnd = new Random();
        var cardEntity = _mapper.Map<SystemCard>(request);
        cardEntity.CardNumber = $"4411{rnd.Next(1000, 9999)}{rnd.Next(1000, 9999)}{rnd.Next(1000, 9999)}";
        cardEntity.CVV = $"{rnd.Next(100,999)}";
        cardEntity.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        cardEntity.Expire = cardEntity.CreatedAt.AddYears(2);

        var result = await _cardRepository.AddAsync(cardEntity);

        return _mapper.Map<AddCardResponse>(result);
    }
}