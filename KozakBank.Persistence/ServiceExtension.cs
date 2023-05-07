using KozakBank.Application.Repositories;
using KozakBank.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KozakBank.Persistence;

public static class ServiceExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration cfg)
    {
        var connString = cfg.GetConnectionString("KozakBank");
        services.AddDbContext<DataContext.DataContext>(opt => opt.UseNpgsql(connString));

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IKozakInfoRepository, KozakInfoRepository>();
        services.AddTransient<IKisaCardRepository, KisaCardRepository>();
        services.AddTransient<IMapsterCardRepository, MapsterCardRepository>();
        services.AddTransient<ITransactionHistoryRepository, TransactionHistoryRepository>();
        services.AddTransient<IBaseUnitOfWork, UnitOfWork>();
    }
}