using MapsterCard.AppDbContext.Entities;
using Microsoft.EntityFrameworkCore;
namespace MapsterCard.AppDbContext;

public class AppDbContext : DbContext
{
    public DbSet<SystemCard> Cards { get; set; }
    public DbSet<MapsterMain> Mapsters { get; set; }

    public AppDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
}