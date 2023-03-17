using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;

namespace MapsterCard.AppDbContext.Repositories;

public sealed class MapsterMainRepository : BaseRepository<MapsterMain>, IMapsterMain
{
    public MapsterMainRepository(AppDbContext context) : base(context)
    {
    }
}