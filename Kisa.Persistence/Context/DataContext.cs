using Kisa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kisa.Persistence.Context;

public sealed class DataContext : DbContext
{
    public DbSet<KisaCard> KisaCards { get; set; }
    public DbSet<KisaMain> KisaMain { get; set; }
    
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
        
    }
}