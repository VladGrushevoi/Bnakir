using KozakBank.Application.Features.UserFeatures.CreateUser;
using KozakBank.Application.Features.UserFeatures.GetUsersByProperties;
using MediatR;

namespace KozakBank.WebApi.Extension.Endpoints;

public static class GroupUserEndpoints
{
    public static RouteGroupBuilder UserEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateUserRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        group.MapPost("/search-by-properties", async (GetUsersByPropertiesRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}