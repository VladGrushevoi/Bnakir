using System.Reflection;
using FluentValidation;
using MapsterCard.Services;
using MediatR;

namespace MapsterCard.ServiceProviders;

public static class AppServiceProvider
{
    public static IServiceCollection AddAppService(this IServiceCollection services)
    {
        services.AddCors();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddAutoMapper(typeof(CardMappingProfile), typeof(SystemMappingProfile));
        return services;
    }
}