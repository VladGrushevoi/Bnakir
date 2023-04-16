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

    public async Task<CreateTransactionResponse> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
    {
        var confirmTransData = request.Adapt<ConfirmTransactionData>();

        float? cardSystemTransactCommission = await _api.GetTransactionCommission(request, cancellationToken);

        if (cardSystemTransactCommission is null or <= 0)
        {
            throw new BadRequestException("Cant get commission transaction");
        }
        
        //get this commission from bank sender of card
        confirmTransData.Commission = request.AmountMoney / 100f * cardSystemTransactCommission.Value;
        var confirmationResult = await _api.ConfirmTransaction(confirmTransData, cancellationToken);
        if (!confirmationResult)
        {
            throw new BadRequestException($"Request data is invalid {request}");
        }

        var shkliftInfos = await _unitOfWork._settingRepository.GetAllAsync(cancellationToken);
        var shkliftSettings = shkliftInfos.ToList();
        var shkliftInfo = shkliftSettings.Last();
        var shkliftCommission = shkliftInfo.TransactionCommission;

        //get this commission from bank sender
        var commissionForThis = request.AmountMoney / 100 * shkliftCommission;
        shkliftInfo.Balance += commissionForThis;
        _ = await _unitOfWork._settingRepository.UpdateAsync(shkliftInfo, cancellationToken);
        
        /*
         * 1. Select transaction type(get commission type from system card) (+)
         * 2. Get money from bank system
         * 3. Send commission money to card system (confirm transaction) (+)
         * 4. Send commission to shklift system (+)
         * 5. Send money to card number 
         */
        
        // send money to card receiver
        
        var transactionEntity = request.Adapt<Transaction>();
        var result = await _unitOfWork._transactionRepository.CreateAsync(transactionEntity, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        var response = result.Adapt<CreateTransactionResponse>();
        return response;
    }
}