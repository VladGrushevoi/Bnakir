using KozakBank.Application.Features.CardFeatures.CreateCardForUser;
using MediatR;

namespace KozakBank.WebApi.Extension.Endpoints;

public static class GroupCardEndpoints
{
    public static RouteGroupBuilder CardEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/create-for-user", async (CreateCardForUserRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}