using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shklift.Persistence.Context;
using Shklift.Persistence.Repositories;
using ShkliftApplication.Repositories;

namespace Shklift.Persistence;

public static class ServiceExtension
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string? connString = configuration.GetConnectionString("ShkliftDb");
        services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connString));

        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ISettingRepository, ShkliftSettingRepository>();
        services.AddScoped<BaseUnitOfWork, UnitOfWork>();
    }
}