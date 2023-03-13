namespace MapsterCard.ServiceProviders;

public static class AppServiceProvider
{
    public static IServiceCollection AddAppService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
}