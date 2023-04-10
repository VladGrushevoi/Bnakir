using MediatR;
using ShkliftApplication.Common.Exception;
using ShkliftApplication.Features.CardSystemApi;
using ShkliftApplication.Features.TransactionFeature.CreateTransaction;

namespace ShkliftApplication.Common.Behavior;

public sealed class TransactionInfoValidation<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{

    private readonly IBaseApi _api;

    public TransactionInfoValidation(IBaseApi api)
    {
        _api = api;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is CreateTransactionRequest createTransactionInfo)
        {
            
            bool result = await _api.IsValidCard(createTransactionInfo, cancellationToken);
            if (!result)
            {
                throw new BadRequestException("Some card does not already to operation");
            }
        }
        return await next();
    }
}

