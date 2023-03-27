using MediatR;

namespace Kisa.Application.Features.CardFeatures.GetCardById;

public sealed record GetCardByIdRequest(Guid Id) : IRequest<GetCardByIdResponse>;