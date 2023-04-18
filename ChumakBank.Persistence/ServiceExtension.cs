using System.Reflection;
using ChumakBank.Application.Repositories;
using ChumakBank.Persistence.Context;
using ChumakBank.Persistence.Repositories;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ChumakBank.Persistence;

public static class ServiceExtension
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbSetting>(configuration.GetSection("DbSetting"));
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb
                => rb.AddPostgres()
                    .WithGlobalConnectionString(configuration.GetConnectionString("ChumakDb"))
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations()
            ).AddLogging(lb => lb.AddFluentMigratorConsole()).BuildServiceProvider(false);

        services.AddSingleton<DataContext>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IChumakRepository, ChumakInfoRepository>();
        services.AddTransient<BaseUnitOfWork, UnitOfWork>();
    }
}