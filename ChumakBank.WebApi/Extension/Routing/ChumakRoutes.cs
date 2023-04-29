using ChumakBank.Application.Features.ChumakInfoFeatures.CreateChumakFeature;
using MediatR;

namespace ChumakBank.WebApi.Extension.Routing;

public static class ChumakRoutes
{
    public static RouteGroupBuilder ChumakRoutesBuild(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateChumakRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        return group;
    }
}