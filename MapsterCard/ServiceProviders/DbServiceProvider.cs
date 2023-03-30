using MapsterCard.AppDbContext.Repositories;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapsterCard.ServiceProviders;

public static class DbServiceProvider
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<AppDbContext.AppDbContext>();
        services.AddDbContextPool<AppDbContext.AppDbContext>(opt =>
            opt.UseNpgsql(config.GetConnectionString("MapsterDbConnection"))
        );

        services.AddScoped<ISystemCard, SystemCardRepository>();
        services.AddScoped<IMapsterMain, MapsterMainRepository>();

        return services;
    }
}