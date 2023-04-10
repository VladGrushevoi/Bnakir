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
        var transactionEntity = request.Adapt<Transaction>();
        var confirmTransData = request.Adapt<ConfirmTransactionData>();
        var confirmationResult = await _api.ConfirmTransaction(confirmTransData, cancellationToken);
        if (!confirmationResult)
        {
            throw new BadRequestException($"Request data is invalid {request}");
        }
        /*
         * 1. Select transaction type(get commission type from system card)
         * 2. Get money from bank system
         * 3. Send commission money to card system (confirm transaction)
         * 4. Send commission to shklift system
         * 5. Send money to card number 
         */
        
        var response = transactionEntity.Adapt<CreateTransactionResponse>();
        return response;
    }
}