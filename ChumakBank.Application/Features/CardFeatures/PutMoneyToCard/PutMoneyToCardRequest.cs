using MediatR;

namespace ChumakBank.Application.Features.CardFeatures.PutMoneyToCard;

public sealed record PutMoneyToCardRequest(
        Guid CardIdFromSysCard,
        float Amount
    ) : IRequest<PutMoneyToCardResponse>;