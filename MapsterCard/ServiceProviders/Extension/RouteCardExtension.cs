using MapsterCard.Services.CardService.AddCard;
using MapsterCard.Services.CardService.CardReadyToOperation;
using MapsterCard.Services.CardService.GetCardById;
using MapsterCard.Services.CardService.GetCardByProperties;
using MediatR;

namespace MapsterCard.ServiceProviders.Extension;

public static class RouteCardExtension
{
    public static RouteGroupBuilder MapSystemCard(this RouteGroupBuilder group)
    {
        group.MapPost("/add", async (AddCardRequest cardReq, IMediator mediator, CancellationToken cls)
            => await mediator.Send(cardReq, cls));
        group.MapGet("/{id:guid}", (Guid id, IMediator mediator, CancellationToken cls)
            => mediator.Send(new GetCardByIdRequest(id), cls));
        group.MapPost("/accept-operation",
            async (CardReadyToOperationRequest req, IMediator mediator, CancellationToken cls)
                => await mediator.Send(req, cls));
        group.MapPost("/search-by-properties",
            async (GetCardByPropertiesRequest req, IMediator mediator, CancellationToken cls)
                => await mediator.Send(req, cls));
        return group;
    }
}