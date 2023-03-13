using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;

namespace MapsterCard.AppDbContext.Repositories;

public class MapsterMainRepository : GenericRepository<MapsterMain>, IMapsterMain
{
    public MapsterMainRepository(AppDbContext context) : base(context)
    {
    }
}