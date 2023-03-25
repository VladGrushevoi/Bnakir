using Kisa.Application.Features.CardFeatures.CreateCard;
using MediatR;

namespace Kisa.WebApi.Extensions;

public static class RouteGroupExtension
{
    public static RouteGroupBuilder CardRoute(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateCardRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}