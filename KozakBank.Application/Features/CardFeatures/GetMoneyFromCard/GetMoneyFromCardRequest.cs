using MediatR;

namespace KozakBank.Application.Features.CardFeatures.GetMoneyFromCard;

public sealed record GetMoneyFromCardRequest(
        Guid IdFromCardSystem,
        float AmountMoney
    ) : IRequest<GetMoneyFromCardResponse>;