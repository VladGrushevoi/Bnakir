using ChumakBank.Application.Repositories;
using ChumakBank.Persistence.Context;
using ChumakBank.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChumakBank.Persistence;

public static class ServiceExtension
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbSetting>(configuration.GetSection("DbSetting"));

        services.AddSingleton<DataContext>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IChumakRepository, ChumakInfoRepository>();
        services.AddTransient<BaseUnitOfWork, UnitOfWork>();
    }
}