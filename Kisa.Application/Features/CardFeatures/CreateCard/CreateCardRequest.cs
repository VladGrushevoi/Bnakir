using MediatR;

namespace Kisa.Application.Features.CardFeatures.CreateCard;

public sealed record CreateCardRequest(string CountryName) : IRequest<CreateCardResponse>;