using Kisa.Application.Repositories;
using Kisa.Persistence.Context;
using Kisa.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kisa.Persistence;

public static class ServiceExtension
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("KisaDb");
        services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connString));

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ICardRepository, KisaCardRepository>();
        services.AddTransient<IKisaMainRepository, MainRepository>();
    }
}