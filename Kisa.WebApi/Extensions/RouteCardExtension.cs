using Kisa.Application.Features.CardFeatures.CardReadyToOperation;
using Kisa.Application.Features.CardFeatures.CreateCard;
using Kisa.Application.Features.CardFeatures.GetCardById;
using MediatR;

namespace Kisa.WebApi.Extensions;

public static class RouteGroupExtension
{
    public static RouteGroupBuilder CardRoute(this RouteGroupBuilder group)
    {
        group.MapPost("/create", 
            async (CreateCardRequest req, IMediator mediator, CancellationToken cls) 
                => await mediator.Send(req, cls));
        group.MapPost("is-ready-card",
            async (CardReadyToOperationRequest req, IMediator mediator, CancellationToken cls) 
                => await mediator.Send(req, cls));
        group.MapGet("/{id:guid}", 
            async (Guid id, IMediator mediator, CancellationToken cls) 
                => await mediator.Send(new GetCardByIdRequest(id), cls));
        return group;
    }
}