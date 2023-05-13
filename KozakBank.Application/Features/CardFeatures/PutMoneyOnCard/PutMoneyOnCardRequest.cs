using MediatR;

namespace KozakBank.Application.Features.CardFeatures.PutMoneyOnCard;

public sealed record PutMoneyOnCardRequest(
        Guid SysCardId,
        float Amount
    ) : IRequest<PutMoneyOnCardResponse>;