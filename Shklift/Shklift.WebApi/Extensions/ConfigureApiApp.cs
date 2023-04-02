namespace Shklift.WebApi.Extensions;

public static class ConfigureApiApp
{
    public static void ConfigurePipeline(this WebApplication app)
    {
        // var serviceScope = app.Services.CreateScope();
        // var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
        // dataContext?.Database.EnsureCreated();
        app.MapGroup("/transaction")
            .TransactionRoute()
            .WithTags("Public");
        app.MapGroup("/system")
            .SystemRoute()
            .WithTags("System");
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseErrorHandler();
        app.UseCors();
    }
}