using MediatR;
using ShkliftApplication.Features.ShkliftSystemFeature.CreateShkliftInfo;
using ShkliftApplication.Features.ShkliftSystemFeature.UpdateShkliftInfo;

namespace Shklift.WebApi.Extensions;

public static class SystemRouteExtension
{
    public static RouteGroupBuilder SystemRoute(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateShkliftInfoRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        group.MapPatch("/update", async (UpdateShkliftInfoRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}