using MediatR;

namespace Kisa.Application.Features.MainFeatures.ConfirmTransaction;

public sealed record ConfirmTransactionRequest(
    CardInfoForTransact Card,
    float Commission
) : IRequest<ConfirmTransactionResponse>;

public sealed record CardInfoForTransact(string CardNumber, string CVV, string ExpireTo);