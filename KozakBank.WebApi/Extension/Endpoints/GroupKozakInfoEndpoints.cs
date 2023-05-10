using KozakBank.Application.Features.KozakInfoFeatures.CreateKozakInfo;
using MediatR;

namespace KozakBank.WebApi.Extension.Endpoints;

public static class GroupKozakInfoEndpoints
{
    public static RouteGroupBuilder KozakInfoEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateKozakInfoRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}