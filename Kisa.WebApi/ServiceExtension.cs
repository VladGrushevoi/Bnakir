using Kisa.Application;
using Kisa.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Kisa.WebApi;

public static class ServiceExtension
{
    public static void ConfigureApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<ApiBehaviorOptions>(opt =>
        {
            opt.SuppressModelStateInvalidFilter = true;
        });
        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
        services.ConfigurePersistence(configuration);
        services.ConfigureApplication();
    }
}