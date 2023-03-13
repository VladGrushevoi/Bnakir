using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;

namespace MapsterCard.AppDbContext.Repositories;

public class SystemCardRepository : GenericRepository<SystemCard>, ISystemCard
{
    public SystemCardRepository(AppDbContext context) : base(context)
    {
    }
}