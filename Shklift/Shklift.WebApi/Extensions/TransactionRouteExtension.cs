using MediatR;
using ShkliftApplication.Features.TransactionFeature.CreateTransaction;

namespace Shklift.WebApi.Extensions;

public static class TransactionRouteExtension
{
    public static RouteGroupBuilder TransactionRoute(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateTransactionRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        
        return group;
    }
}