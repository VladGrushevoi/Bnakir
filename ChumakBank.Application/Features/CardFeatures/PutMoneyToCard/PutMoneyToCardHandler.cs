using AutoMapper;
using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using MediatR;

namespace ChumakBank.Application.Features.CardFeatures.PutMoneyToCard;

public sealed class PutMoneyToCardHandler : IRequestHandler<PutMoneyToCardRequest, PutMoneyToCardResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PutMoneyToCardHandler(BaseUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PutMoneyToCardResponse> Handle(PutMoneyToCardRequest request, CancellationToken cancellationToken)
    {
        var allKisaCards = await _unitOfWork.KisaCardRepository.GetAllAsync(cancellationToken);
        var allMapsterCard = await _unitOfWork.MapsterCardRepository.GetAllAsync(cancellationToken);
        KisaCard kisaCard = allKisaCards.SingleOrDefault(src => src.CardIdFromSystem == request.CardIdFromSysCard);
        MapsterCard mapsterCard = allMapsterCard.SingleOrDefault(src => src.CardIdFromSystem == request.CardIdFromSysCard);
        PutMoneyToCardResponse result = null;
        if (kisaCard != default)
        {
            kisaCard.Balance += request.Amount;
            kisaCard.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
            kisaCard = await _unitOfWork.KisaCardRepository.UpdateAsync(kisaCard, cancellationToken);
            result = _mapper.Map<PutMoneyToCardResponse>(kisaCard);
        }

        if (mapsterCard != default)
        {
            mapsterCard.Balance += request.Amount;
            mapsterCard.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
            mapsterCard = await _unitOfWork.MapsterCardRepository.UpdateAsync(mapsterCard, cancellationToken);
            result = _mapper.Map<PutMoneyToCardResponse>(mapsterCard);
        }

        await _unitOfWork.SaveAsync(cancellationToken);

        return result;
    }
}