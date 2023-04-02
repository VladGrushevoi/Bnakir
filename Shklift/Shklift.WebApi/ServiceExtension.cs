using Microsoft.AspNetCore.Mvc;
using Shklift.Persistence;
using ShkliftApplication;

namespace Shklift.WebApi;

public static class ServiceExtension
{
    public static void ConfigureWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
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