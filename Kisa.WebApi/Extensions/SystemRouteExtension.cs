using Kisa.Application.Features.MainFeatures.CreateMainSetting;
using Kisa.Application.Features.MainFeatures.UpdateMainSetting;
using MediatR;

namespace Kisa.WebApi.Extensions;

public static class SystemRouteExtension
{
    public static RouteGroupBuilder SystemRoute(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateMainSettingRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        group.MapPatch("/update", async (UpdateMainSettingRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}