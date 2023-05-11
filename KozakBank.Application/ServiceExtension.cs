using System.Reflection;
using FluentValidation;
using KozakBank.Application.Common.Behavior;
using KozakBank.Application.Common.UseCardSystem;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace KozakBank.Application;

public static class ServiceExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            }
        );
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddSingleton<UseCardSystemApi>();
        services.AddScoped<UseCardSystemApiWrapper>();
    }
}