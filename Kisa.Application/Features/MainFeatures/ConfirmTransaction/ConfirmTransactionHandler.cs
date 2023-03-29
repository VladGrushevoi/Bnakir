using AutoMapper;
using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using MediatR;

namespace Kisa.Application.Features.MainFeatures.ConfirmTransaction;

public class ConfirmTransactionHandler : IRequestHandler<ConfirmTransactionRequest, ConfirmTransactionResponse>
{
    private readonly IMapper _mapper;
    private readonly IKisaMainRepository _kisaMainRepository;
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ConfirmTransactionHandler(IMapper mapper, IKisaMainRepository kisaMainRepository, ICardRepository cardRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _kisaMainRepository = kisaMainRepository;
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ConfirmTransactionResponse> Handle(ConfirmTransactionRequest request, CancellationToken cancellationToken)
    {
        var cardEntity = _mapper.Map<KisaCard>(request);
        var cards = await _cardRepository.FindCardsByProperties(cardEntity, cancellationToken);
        if (!cards.Any())
        {
            return _mapper.Map<ConfirmTransactionResponse>(new KisaCard()
                { ExpireTo = DateOnly.FromDateTime(DateTime.Now).AddYears(-100) });
        }

        var card = cards.First();
        
        if (card.ExpireTo >= DateOnly.FromDateTime(DateTime.Now))
        {
            var kisaSettings = await _kisaMainRepository.GetAllAsync(cancellationToken);
            var kisaSetting = kisaSettings.Last();
            kisaSetting.Balance += request.Commission;
            await _kisaMainRepository.UpdateAsync(kisaSetting, cancellationToken);

            await _unitOfWork.SaveAsync(cancellationToken);
            return _mapper.Map<ConfirmTransactionResponse>(card);
        }
        
        return _mapper.Map<ConfirmTransactionResponse>(new KisaCard()
            { ExpireTo = DateOnly.FromDateTime(DateTime.Now).AddYears(-100) });
    }
}