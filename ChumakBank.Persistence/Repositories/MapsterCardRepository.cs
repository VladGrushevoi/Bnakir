using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using ChumakBank.Persistence.Context;

namespace ChumakBank.Persistence.Repositories;

public sealed class MapsterCardRepository : BaseRepository<MapsterCard>, IMapsterCardRepository
{
    public MapsterCardRepository(DataContext context) : base(context)
    {
    }
}