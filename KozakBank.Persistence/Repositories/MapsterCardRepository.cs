using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;

namespace KozakBank.Persistence.Repositories;

public sealed class MapsterCardRepository : BaseRepository<MapsterCard>, IMapsterCardRepository
{
    public MapsterCardRepository(DataContext.DataContext context) : base(context)
    {
    }
}