using ChumakBank.Persistence.Context;

namespace ChumakBank.WebApi.Extension;

public static class UseDataContext
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbService = scope.ServiceProvider.GetRequiredService<DataContext>();

        try
        {
            dbService.CreateDatabase().Wait();
        }
        catch (Exception e)
        {
                
        }
    }
}