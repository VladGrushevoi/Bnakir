using ChumakBank.Application;
using ChumakBank.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ChumakBank.WebApi;

public static class ServiceExtension
{
    public static void ConfigureWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);
        services.AddCors((opt) =>
        {
            opt.AddDefaultPolicy(builder =>
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
            );
        });

        services.ConfigurePersistence(configuration);
        services.ConfigureApplication();
    }
}