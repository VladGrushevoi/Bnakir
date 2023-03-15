using System.Reflection;
using FluentValidation;
using MediatR;

namespace MapsterCard.ServiceProviders;

public static class AppServiceProvider
{
    public static IServiceCollection AddAppService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}