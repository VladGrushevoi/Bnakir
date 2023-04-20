using ChumakBank.Application.Features.UserFeatures.CreateUserFeature;
using ChumakBank.Application.Features.UserFeatures.UpdateUserFeature;
using MediatR;

namespace ChumakBank.WebApi.Extension.Routing;

public static class UserRoutes
{
    public static RouteGroupBuilder UserRouteBuild(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateUserRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        group.MapPatch("/update", async (UpdateUserRequest req, IMediator mediator, CancellationToken cls) 
            => await mediator.Send(req, cls));
        return group;
    }
}