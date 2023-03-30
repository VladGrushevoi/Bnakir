using Kisa.Application.Features.MainFeatures.ConfirmTransaction;
using Kisa.Application.Features.MainFeatures.CreateMainSetting;
using Kisa.Application.Features.MainFeatures.GetCommissionBetweenCountry;
using Kisa.Application.Features.MainFeatures.GetCommissionInCountry;
using Kisa.Application.Features.MainFeatures.UpdateMainSetting;
using MediatR;

namespace Kisa.WebApi.Extensions;

public static class SystemRouteExtension
{
    public static RouteGroupBuilder SystemRoute(this RouteGroupBuilder group)
    {
        group.MapPost("/create", async (CreateMainSettingRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        group.MapPatch("/update", async (UpdateMainSettingRequest req, IMediator mediator, CancellationToken cls)
            => await mediator.Send(req, cls));
        group.MapPost("/confirm-transaction",
            async (ConfirmTransactionRequest req, IMediator mediator, CancellationToken cls)
                => await mediator.Send(req, cls));
        group.MapGet("/commission-in-country", async (IMediator mediator, CancellationToken cls)
            => await mediator.Send(new GetCommissionInCountryRequest(), cls));
        group.MapGet("/commission-between-country", async (IMediator mediator, CancellationToken cls)
            => await mediator.Send(new GetCommissionBetweenCountryRequest(), cls));
        return group;
    }
}