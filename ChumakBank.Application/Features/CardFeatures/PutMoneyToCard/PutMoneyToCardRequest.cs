using MediatR;

namespace ChumakBank.Application.Features.CardFeatures.PutMoneyToCard;

public sealed record PutMoneyToCardRequest(
        Guid SysCardId,
        float Amount
    ) : IRequest<PutMoneyToCardResponse>;