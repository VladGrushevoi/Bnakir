using AutoMapper;
using KozakBank.Application.Common.Exceptions;
using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;
using MediatR;

namespace KozakBank.Application.Features.CardFeatures.GetMoneyFromCard;

public sealed class GetMoneyFromCardHandler : IRequestHandler<GetMoneyFromCardRequest, GetMoneyFromCardResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseUnitOfWork _unitOfWork;

    public GetMoneyFromCardHandler(IMapper mapper, IBaseUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetMoneyFromCardResponse> Handle(GetMoneyFromCardRequest request, CancellationToken cancellationToken)
    {
        var kisaCardEntity = _mapper.Map<KisaCard>(request);
        var mapsterCardEntity = _mapper.Map<MapsterCard>(request);
        var kozakInfo = (await _unitOfWork.KozakInfoRepository
            .GetAllAsync(cancellationToken)).OrderBy(x => x.CreatedOnly).Last();

        if (await _unitOfWork.KisaCardRepository.GetAsync(kisaCardEntity.Id, cancellationToken) is KisaCard kC)
        {
            if (kC.Balance > request.AmountMoney)
            {
                var commission = request.AmountMoney / 100 * kozakInfo.CommissionValue;
                var result = new GetMoneyFromCardResponse() { Money = request.AmountMoney};
                kC.Balance -= request.AmountMoney;
                if (kC.Balance >= commission)
                {
                    kC.Balance -= commission;
                    kozakInfo.Balance += commission;
                    var transaction = new TransactionHistory()
                    {
                        CardId = kC.Id,
                        AmountMoney = request.AmountMoney,
                        Commission = commission
                    };

                    var transactionEntity =
                        await _unitOfWork.TransactionHistoryRepository.CreateAsync(transaction, cancellationToken);
                    var kisaCardUpdate = await _unitOfWork.KisaCardRepository.UpdateAsync(kC, cancellationToken);
                    var kozakInfoUpdate =
                        await _unitOfWork.KozakInfoRepository.UpdateAsync(kozakInfo, cancellationToken);
                    await _unitOfWork.SaveAsync(cancellationToken);
                    return result;
                }
            }
        }
        
        if (await _unitOfWork.MapsterCardRepository.GetAsync(mapsterCardEntity.Id, cancellationToken) is MapsterCard mpC)
        {
            if (mpC.Balance > request.AmountMoney)
            {
                var commission = request.AmountMoney / 100 * kozakInfo.CommissionValue;
                var result = new GetMoneyFromCardResponse() { Money = request.AmountMoney};
                mpC.Balance -= request.AmountMoney;
                if (mpC.Balance >= commission)
                {
                    mpC.Balance -= commission;
                    kozakInfo.Balance += commission;
                    var transaction = new TransactionHistory()
                    {
                        CardId = mpC.Id,
                        AmountMoney = request.AmountMoney,
                        Commission = commission
                    };

                    var transactionEntity =
                        await _unitOfWork.TransactionHistoryRepository.CreateAsync(transaction, cancellationToken);
                    var kisaCardUpdate = await _unitOfWork.MapsterCardRepository.UpdateAsync(mpC, cancellationToken);
                    var kozakInfoUpdate =
                        await _unitOfWork.KozakInfoRepository.UpdateAsync(kozakInfo, cancellationToken);
                    await _unitOfWork.SaveAsync(cancellationToken);
                    return result;
                }
            }
        }

        throw new InternalError("Card not have money");
    }
}