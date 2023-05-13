using AutoMapper;
using KozakBank.Application.Common.Exceptions;
using KozakBank.Application.Repositories;
using KozakBank.Domain.Common;
using MediatR;

namespace KozakBank.Application.Features.CardFeatures.PutMoneyOnCard;

public sealed class PutMoneyOnCardHandler : IRequestHandler<PutMoneyOnCardRequest, PutMoneyOnCardResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseUnitOfWork _unitOfWork;

    public PutMoneyOnCardHandler(IMapper mapper, IBaseUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PutMoneyOnCardResponse> Handle(PutMoneyOnCardRequest request, CancellationToken cancellationToken)
    {
        var baseCard = _mapper.Map<BaseCard>(request);
        var kisaCard = await _unitOfWork.KisaCardRepository.GetAsync(baseCard.Id, cancellationToken);
        var mapsterCard = await _unitOfWork.MapsterCardRepository.GetAsync(baseCard.Id, cancellationToken);

        if (kisaCard != null)
        {
            kisaCard.Balance += request.Amount;
            var updatedKisaCard = await _unitOfWork.KisaCardRepository.UpdateAsync(kisaCard, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<PutMoneyOnCardResponse>(updatedKisaCard);
        }
        if (mapsterCard != null)
        {
            mapsterCard.Balance += request.Amount;
            var updatedMapsterCard = await _unitOfWork.MapsterCardRepository.UpdateAsync(mapsterCard, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<PutMoneyOnCardResponse>(updatedMapsterCard);
        }

        throw new BadRequestException("Not found a card");
    }
}