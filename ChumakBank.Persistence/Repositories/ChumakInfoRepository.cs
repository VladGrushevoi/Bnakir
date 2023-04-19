using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using ChumakBank.Persistence.Context;

namespace ChumakBank.Persistence.Repositories;

public sealed class ChumakInfoRepository : BaseRepository<ChumakInfo>, IChumakRepository
{
    public ChumakInfoRepository(DataContext context) : base(context)
    {
    }
}