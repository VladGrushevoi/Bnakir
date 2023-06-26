using AutoMapper;
using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using MediatR;

namespace Kisa.Application.Features.CardFeatures.CreateCard;

public sealed class CreateCardHandler : IRequestHandler<CreateCardRequest, CreateCardResponse>
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCardHandler(IMapper mapper, ICardRepository cardRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCardResponse> Handle(CreateCardRequest request, CancellationToken cancellationToken)
    {
        Random rnd = new();
        var cardEntity = _mapper.Map<KisaCard>(request);
        cardEntity.CardNumber = "4412" + request.BankIdentifier + rnd.Next(1000, 9999) + rnd.Next(1000, 9999);
        cardEntity.CVV = rnd.Next(100, 999).ToString();
        cardEntity.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        cardEntity.ExpireTo = cardEntity.CreatedAt.Value.AddYears(3);
        cardEntity.ShortExpireTo = cardEntity.ExpireTo.Value.ToString("MM.yy");

        var result = await _cardRepository.CreateAsync(cardEntity, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<CreateCardResponse>(result);
    }
}