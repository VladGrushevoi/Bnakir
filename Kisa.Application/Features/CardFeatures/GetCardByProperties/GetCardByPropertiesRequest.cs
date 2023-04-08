using MediatR;

namespace Kisa.Application.Features.CardFeatures.GetCardByProperties;

public sealed record GetCardByPropertiesRequest(
        string CardNumber,
        string CVV,
        string ExpireTo,
        string CreatedAt,
        string CountryName
    ) : IRequest<GetCardByPropertiesResponse>;