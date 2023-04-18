namespace ChumakBank.WebApi.Extension;

public static class ConfigurePipelineApi
{
    public static void ConfigurePipeline(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.ExceptionHandler();
    }
}