using Microsoft.EntityFrameworkCore;
using Shklift.Domain.Entities;

namespace Shklift.Persistence.Context;

public sealed class DataContext : DbContext
{
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<ShkliftSetting> ShkliftSettings { get; set; }
    
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
        
    }
}