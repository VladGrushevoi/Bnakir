using MediatR;
using ShkliftApplication.Features.ShkliftSystemFeature.CreateShkliftInfo;

namespace Shklift.WebApi.Extensions;

public static class SystemRouteExtension
{
    public static RouteGroupBuilder SystemRoute(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateShkliftInfoRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}