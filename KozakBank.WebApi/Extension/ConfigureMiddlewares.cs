using KozakBank.Persistence.DataContext;
using KozakBank.WebApi.Extension.Endpoints;

namespace KozakBank.WebApi.Extension;

public static class ConfigureMiddlewares
{
    public static void ConfigureWebApiMiddlewares(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
        dataContext?.Database.EnsureCreated();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();
        app.UseGlobalExtensionHandler();
        app.MapGroup("/user")
            .UserEndpoints()
            .WithTags("User endpoints");
    }
}