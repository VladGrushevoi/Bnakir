using System.Reflection;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShkliftApplication.Common;
using ShkliftApplication.Common.Behavior;

namespace ShkliftApplication;

public static class ServiceExtension
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddMapster();
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        Assembly appAssembly = typeof(BaseDto<,>).Assembly;
        typeAdapterConfig.Scan(appAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
    }
}