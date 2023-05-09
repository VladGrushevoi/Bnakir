using KozakBank.Application.Features.UserFeatures.CreateUser;
using MediatR;

namespace KozakBank.WebApi.Extension.Endpoints;

public static class GroupUserEndpoints
{
    public static RouteGroupBuilder UserEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateUserRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}