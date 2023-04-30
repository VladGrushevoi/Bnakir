using MediatR;

namespace Kisa.Application.Features.CardFeatures.CreateCard;

public sealed record CreateCardRequest(
    string CountryName,
    string BankIdentifier
    ) : IRequest<CreateCardResponse>;