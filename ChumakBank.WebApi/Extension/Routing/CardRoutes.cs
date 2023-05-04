using ChumakBank.Application.Features.CardFeatures.GetMoneyFromCard;
using ChumakBank.Application.Features.CardFeatures.PutMoneyToCard;
using MediatR;

namespace ChumakBank.WebApi.Extension.Routing;

public static class CardRoutes
{
    public static RouteGroupBuilder CardRoutesBuilder(this RouteGroupBuilder group)
    {
        group.MapPost("/put-money", async (PutMoneyToCardRequest req, IMediator mediator, CancellationToken cls) 
            => await mediator.Send(req, cls));
        group.MapPost("get-money", async (GetMoneyFromCardRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}