using ChumakBank.WebApi.Extension.Routing;

namespace ChumakBank.WebApi.Extension;

public static class ConfigurePipelineApi
{
    public static void ConfigurePipeline(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapGroup("/user")
            .UserRouteBuild()
            .WithTags("UserEndpoints");
        app.ExceptionHandler();
    }
}