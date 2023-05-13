using MediatR;

namespace KozakBank.Application.Features.CardFeatures.GetMoneyFromCard;

public sealed record GetMoneyFromCardRequest(
        Guid SysCardId,
        float AmountMoney
    ) : IRequest<GetMoneyFromCardResponse>;