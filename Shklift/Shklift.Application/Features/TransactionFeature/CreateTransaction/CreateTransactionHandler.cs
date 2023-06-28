using Mapster;
using MediatR;
using Shklift.Domain.Entities;
using ShkliftApplication.Common.Exception;
using ShkliftApplication.Features.CardSystemApi;
using ShkliftApplication.Features.CardSystemApi.Models.Request;
using ShkliftApplication.Repositories;

namespace ShkliftApplication.Features.TransactionFeature.CreateTransaction;

public sealed class CreateTransactionHandler : IRequestHandler<CreateTransactionRequest, CreateTransactionResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;
    private readonly IBaseApi _api;

    public CreateTransactionHandler(BaseUnitOfWork unitOfWork, IBaseApi api)
    {
        _unitOfWork = unitOfWork;
        _api = api;
    }

    public async Task<CreateTransactionResponse> Handle(CreateTransactionRequest request,
        CancellationToken cancellationToken)
    {
        var confirmTransData = request.Adapt<ConfirmTransactionData>();
        var shkliftInfos = await _unitOfWork._settingRepository.GetAllAsync(cancellationToken);
        var shkliftSettings = shkliftInfos.ToList();
        var shkliftInfo = shkliftSettings.Last();
        var shkliftCommission = shkliftInfo.TransactionCommission;

        float? systemCardCommission = await _api.GetTransactionCommission(request, cancellationToken);

        if (systemCardCommission is null or <= 0)
        {
            throw new BadRequestException("Cant get commission transaction");
        }

        var senderCardInfo = await _api.GetCardInfo(new Card()
        {
            CardNumber = request.FromCardNumber,
            ShortExpireTo = request.FromCardShortExpire,
            CVV = request.FromCardCVV
        }, cancellationToken);
        var receiverCardInfo = await _api.GetCardInfo(new Card()
        {
            CardNumber = request.CardNumberReceiver
        }, cancellationToken);

        var allSpendMoney = request.AmountMoney
                            + (request.AmountMoney / 100f * systemCardCommission)
                            + (request.AmountMoney / 100f * shkliftCommission);
        var gettingMoneyFromCard = await _api.GetMoneyFromBank(new GetMoneyFromBankRequest()
        {
            IdFromCardSystem = senderCardInfo.Id,
            AmountMoney = allSpendMoney.Value,
            CardNumber = senderCardInfo.CardNumber
        }, cancellationToken);
        confirmTransData.Commission = gettingMoneyFromCard.Money -
                                      (gettingMoneyFromCard.Money -
                                       (request.AmountMoney / 100f * systemCardCommission.Value));
        gettingMoneyFromCard.Money -= confirmTransData.Commission;
        var confirmationResult = await _api.ConfirmTransaction(confirmTransData, cancellationToken);
        if (!confirmationResult)
        {
            throw new BadRequestException($"Request data is invalid {request}");
        }

        var commissionForThis = gettingMoneyFromCard.Money -
                                (gettingMoneyFromCard.Money - (request.AmountMoney / 100 * shkliftCommission));
        shkliftInfo.Balance += commissionForThis;
        gettingMoneyFromCard.Money -= commissionForThis;
        _ = await _unitOfWork._settingRepository.UpdateAsync(shkliftInfo, cancellationToken);

        var sendMoneyResult = await _api.SendMoneyToBank(new SendMoneyToBankRequest()
        {
            SysCardId = receiverCardInfo.Id,
            Amount = gettingMoneyFromCard.Money,
            CardNumber = receiverCardInfo.CardNumber
        }, cancellationToken);

        var transactionEntity = request.Adapt<Transaction>();
        var result = await _unitOfWork._transactionRepository.CreateAsync(transactionEntity, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        var response = result.Adapt<CreateTransactionResponse>();
        return response;
    }
}