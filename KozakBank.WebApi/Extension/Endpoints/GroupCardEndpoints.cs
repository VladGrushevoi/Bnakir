using KozakBank.Application.Features.CardFeatures.CreateCardForUser;
using KozakBank.Application.Features.CardFeatures.GetMoneyFromCard;
using KozakBank.Application.Features.CardFeatures.PutMoneyOnCard;
using MediatR;

namespace KozakBank.WebApi.Extension.Endpoints;

public static class GroupCardEndpoints
{
    public static RouteGroupBuilder CardEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/create-for-user", async (CreateCardForUserRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        group.MapPost("/get-money", async (GetMoneyFromCardRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        group.MapPost("/put-money", async (PutMoneyOnCardRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));

        return group;
    }
}