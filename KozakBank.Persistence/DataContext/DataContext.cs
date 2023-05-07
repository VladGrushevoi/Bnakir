using KozakBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KozakBank.Persistence.DataContext;

public sealed class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<KozakInfo> KozakInfos { get; set; }
    public DbSet<KisaCard> KisaCards { get; set; }
    public DbSet<MapsterCard> MapsterCards { get; set; }
    public DbSet<TransactionHistory> TransactionHistories { get; set; }

    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
        
    }
}