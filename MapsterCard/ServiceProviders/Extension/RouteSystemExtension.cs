using MapsterCard.Services.SystemService.AddSystemSettings;
using MediatR;

namespace MapsterCard.ServiceProviders.Extension;

public static class RouteSystemExtension
{
    public static RouteGroupBuilder RouteSystemGroup(this RouteGroupBuilder group)
    {
        group.MapPost("/add",
            async (AddSystemSettingsRequest req, IMediator mediatr, CancellationToken cls) 
                => await mediatr.Send(req, cls));
        return group;
    }
}