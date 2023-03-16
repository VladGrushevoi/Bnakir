using MapsterCard.AppDbContext.Repositories.Interfaces;
using MapsterCard.Services.CardService.AddCard;
using MapsterCard.Services.CardService.GetCardById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MapsterCard.ServiceProviders.Extension;

public static class RouteExtension
{
    public static RouteGroupBuilder MapSystemCard(this RouteGroupBuilder group)
    {
        group.MapPost("/add", async (AddCardRequest cardReq, IMediator mediator, CancellationToken cls) 
            => await mediator.Send(cardReq,cls));
        group.MapGet("/{id:guid}", (Guid id, IMediator mediator, CancellationToken cls) 
            => mediator.Send(new GetCardByIdRequest(id), cls));
        return group;
    }
}