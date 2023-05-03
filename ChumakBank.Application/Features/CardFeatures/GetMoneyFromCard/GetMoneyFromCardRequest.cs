using MediatR;

namespace ChumakBank.Application.Features.CardFeatures.GetMoneyFromCard;

public sealed record GetMoneyFromCardRequest(
    string IdFromCardSystem,
    float AmountMoney
    ) : IRequest<GetMoneyFromCardResponse>;