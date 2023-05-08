using KozakBank.Application;
using KozakBank.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace KozakBank.WebApi;

public static class ServiceExtension
{
    public static void AddWebApiServices(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);
        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });
        });

        services.AddApplicationServices();
        services.AddInfrastructureServices(cfg);
    }
}