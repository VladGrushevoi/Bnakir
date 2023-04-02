using Mapster;
using MediatR;
using Shklift.Domain.Entities;
using ShkliftApplication.Repositories;

namespace ShkliftApplication.Features.TransactionFeature.CreateTransaction;

public sealed class CreateTransactionHandler : IRequestHandler<CreateTransactionRequest, CreateTransactionResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;

    public CreateTransactionHandler(BaseUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateTransactionResponse> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
    {
        var transactionEntity = request.Adapt<Transaction>();
        
        var response = transactionEntity.Adapt<CreateTransactionResponse>();
        return response;
    }
}