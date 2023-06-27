using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.CardService.AddCard;

public sealed class AddCardHandler : IRequestHandler<AddCardRequest, AddCardResponse>
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
        cardEntity.CardNumber = $"4411{request.BankIdentifier}{rnd.Next(1000, 9999)}{rnd.Next(1000, 9999)}";
        cardEntity.CVV = $"{rnd.Next(100, 999)}";
        cardEntity.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        cardEntity.ExpireTo = cardEntity.CreatedAt.Value.AddYears(2);
        cardEntity.ShortExpireTo = cardEntity.ExpireTo.Value.ToString("MM.yy");

        var result = await _cardRepository.AddAsync(cardEntity);

        return _mapper.Map<AddCardResponse>(result);
    }
}