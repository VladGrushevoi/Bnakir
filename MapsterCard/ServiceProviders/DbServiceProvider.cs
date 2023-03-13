using Microsoft.EntityFrameworkCore;

namespace MapsterCard.ServiceProviders;

public static class DbServiceProvider
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext.AppDbContext>(opt =>
            opt.UseNpgsql(config.GetConnectionString("MapsterDbConnection"))
        );
        

        return services;
    }
}