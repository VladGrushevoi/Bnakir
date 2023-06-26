using MediatR;

namespace Kisa.Application.Features.CardFeatures.CardReadyToOperation;

public sealed record CardReadyToOperationRequest(string CardNumber, string CVV, string ExpireToShort)
    : IRequest<CardReadyToOperationResponse>;