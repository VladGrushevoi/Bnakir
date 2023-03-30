using MediatR;

namespace Kisa.Application.Features.MainFeatures.GetCommissionBetweenCardSystems;

public sealed record GetCommissionBetweenCardSystemsRequest
    : IRequest<GetCommissionBetweenCardSystemsResponse>;