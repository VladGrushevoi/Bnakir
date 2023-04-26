using System.Reflection;
using ChumakBank.Application.Common.Behavior;
using ChumakBank.Application.Common.CardSystemsCallerApi;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChumakBank.Application;

public static class ServiceExtension
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            }
        );
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSingleton<SystemCardCallerApi>();
        services.AddSingleton<CallerCardSystemApiWrapper>();
    }
}