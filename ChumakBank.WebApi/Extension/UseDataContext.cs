using ChumakBank.Application.Common.Exception;
using ChumakBank.Persistence.Context;
using FluentMigrator.Runner;

namespace ChumakBank.WebApi.Extension;

public static class UseDataContext
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbService = scope.ServiceProvider.GetRequiredService<DataContext>();
        var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        try
        {
            dbService.CreateDatabase();
            
            migrationService.ListMigrations();
            migrationService.MigrateUp();
        }
        catch (Exception e)
        {
            throw new InternalException(e.Message);
        }
    }
}