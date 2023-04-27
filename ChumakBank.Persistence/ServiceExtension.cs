using System.Reflection;
using ChumakBank.Application.Repositories;
using ChumakBank.Persistence.Context;
using ChumakBank.Persistence.Helpers.SqlMappers;
using ChumakBank.Persistence.Repositories;
using Dapper;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());
        SqlMapper.AddTypeHandler(new SqlGuidTypeHandler());
        services.AddScoped<DataContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IChumakRepository, ChumakInfoRepository>();
        services.AddScoped<IKisaCardRepository, KisaCardRepository>();
        services.AddScoped<IMapsterCardRepository, MapsterCardRepository>();
        services.AddScoped<BaseUnitOfWork, UnitOfWork>();
    }
}