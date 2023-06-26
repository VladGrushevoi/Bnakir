using Kisa.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kisa.WebApi.Extensions;

public static class ConfigureApiApp
{
    public static void ConfigureApi(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
        dataContext?.Database.EnsureCreated();
        //dataContext?.Database.Migrate();
        app.MapGroup("/card")
            .CardRoute()
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