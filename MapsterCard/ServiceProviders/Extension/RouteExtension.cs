using MapsterCard.AppDbContext.Repositories.Interfaces;
using MapsterCard.Services.CardService.AddCard;
using MediatR;

namespace MapsterCard.ServiceProviders.Extension;

public static class RouteExtension
{
    public static RouteGroupBuilder MapSystemCard(this RouteGroupBuilder group, ISystemCard? cardRepo)
    {
        group.MapPost("/add", async (AddCardRequest cardReq, IMediator mediator, CancellationToken cls) => await mediator.Send(cardReq,cls));
        return group;
    }
}