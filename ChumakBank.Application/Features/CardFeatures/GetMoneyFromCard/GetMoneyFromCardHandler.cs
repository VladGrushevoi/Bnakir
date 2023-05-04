using System.Linq.Expressions;
using AutoMapper;
using ChumakBank.Application.Common.Exception;
using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using MediatR;

namespace ChumakBank.Application.Features.CardFeatures.GetMoneyFromCard;

public sealed class GetMoneyFromCardHandler : IRequestHandler<GetMoneyFromCardRequest, GetMoneyFromCardResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMoneyFromCardHandler(IMapper mapper, BaseUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetMoneyFromCardResponse> Handle(GetMoneyFromCardRequest request, CancellationToken cancellationToken)
    {
        var kisaCardRequest = _mapper.Map<KisaCard>(request);
        var mapsterCardRequest = _mapper.Map<MapsterCard>(request);
        var percentOfOperation = (await _unitOfWork.ChumakRepository.GetAllAsync(cancellationToken)).Last().CommissionForOperation;

        var kisaCardEntity = 
            (await _unitOfWork.KisaCardRepository.GetAllAsync(cancellationToken))
            .FirstOrDefault(x => x.CardIdFromSystem == kisaCardRequest.CardIdFromSystem);
        var mapsterCardEntity = 
            (await _unitOfWork.MapsterCardRepository.GetAllAsync(cancellationToken))
            .FirstOrDefault(x => x.CardIdFromSystem == mapsterCardRequest.CardIdFromSystem);
        GetMoneyFromCardResponse result;
        if (kisaCardEntity is not (null))
        {
            if (kisaCardEntity.Balance > request.AmountMoney)
            {
                var commission = request.AmountMoney / 100 * percentOfOperation;
                result = new GetMoneyFromCardResponse(request.AmountMoney);
                kisaCardEntity.Balance -= request.AmountMoney;
                if (kisaCardEntity.Balance >= commission)
                {
                    kisaCardEntity.Balance -= commission;
                    var transaction = new TransactionHistory
                    {
                        Id = Guid.NewGuid(),
                        FromCardId = kisaCardEntity.Id,
                        AmountMoney = request.AmountMoney,
                        CreatedAt = DateOnly.FromDateTime(DateTime.Now)
                    };

                    var transactHist =
                        await _unitOfWork.TransactionHistoryRepository.CreateAsync(transaction, cancellationToken);
                    var updateKisaCard =
                        await _unitOfWork.KisaCardRepository.UpdateAsync(kisaCardEntity, cancellationToken);
                    await _unitOfWork.SaveAsync(cancellationToken);
                    return result;
                }
            }
        }
        if (mapsterCardEntity is not (null))
        {
            if (mapsterCardEntity.Balance > request.AmountMoney)
            {
                var commission = request.AmountMoney / 100 * percentOfOperation;
                result = new GetMoneyFromCardResponse(request.AmountMoney);
                mapsterCardEntity.Balance -= request.AmountMoney;
                if (mapsterCardEntity.Balance >= commission)
                {
                    mapsterCardEntity.Balance -= commission;
                    var transaction = new TransactionHistory
                    {
                        Id = Guid.NewGuid(),
                        FromCardId = mapsterCardEntity.Id,
                        AmountMoney = request.AmountMoney,
                        CreatedAt = DateOnly.FromDateTime(DateTime.Now)
                    };

                    var transactHist =
                        await _unitOfWork.TransactionHistoryRepository.CreateAsync(transaction, cancellationToken);
                    var updateKisaCard =
                        await _unitOfWork.MapsterCardRepository.UpdateAsync(mapsterCardEntity, cancellationToken);
                    await _unitOfWork.SaveAsync(cancellationToken);
                    return result;
                }
            }
        }

        throw new BadRequestException("Card does not have money");
    }
}