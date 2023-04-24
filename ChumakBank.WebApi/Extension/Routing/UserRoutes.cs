using ChumakBank.Application.Features.UserFeatures.CreateUserFeature;
using ChumakBank.Application.Features.UserFeatures.DeleteUserFeature;
using ChumakBank.Application.Features.UserFeatures.GetAllUsersFeature;
using ChumakBank.Application.Features.UserFeatures.UpdateUserFeature;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChumakBank.WebApi.Extension.Routing;

public static class UserRoutes
{
    public static RouteGroupBuilder UserRouteBuild(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateUserRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        group.MapPatch("/update", async (UpdateUserRequest req, IMediator mediator, CancellationToken cls) 
            => await mediator.Send(req, cls));
        group.MapGet("/all", async (IMediator mediator, CancellationToken cls) 
            => await mediator.Send(new GetAllUsersRequest(), cls));
        group.MapDelete("/delete", async ([FromBody] DeleteUserRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}