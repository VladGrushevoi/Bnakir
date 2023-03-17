using System.ComponentModel.DataAnnotations.Schema;
using MapsterCard.Services.SystemService.AddSystemSettings;
using MapsterCard.Services.SystemService.GetPercentage;
using MapsterCard.Services.SystemService.UpdatePercentage;
using MediatR;

namespace MapsterCard.ServiceProviders.Extension;

public static class RouteSystemExtension
{
    public static RouteGroupBuilder RouteSystemGroup(this RouteGroupBuilder group)
    {
        group.MapPost("/add",
            async (AddSystemSettingsRequest req, IMediator mediatr, CancellationToken cls)
                => await mediatr.Send(req, cls));
        group.MapPatch("/update", async (UpdatePercentageRequest req, IMediator mediator, CancellationToken cls)
                => await mediator.Send(req, cls));
        group.MapGet("/percentage-in-country",
            async (IMediator mediator, CancellationToken cls)
                => await mediator.Send(new GetPercentageInCountryRequest(), cls));
        group.MapGet("/percentage-between-country",
            async (IMediator mediator, CancellationToken cls)
                => await mediator.Send(new GetPercentageBetweenCountryRequest(), cls));
        group.MapGet("/percentage-between-card-system",
            async (IMediator mediator, CancellationToken cls)
                => await mediator.Send(new GetPercentageBetweenCardSystemRequest(), cls));
        return group;
    }
}