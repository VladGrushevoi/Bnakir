using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using ChumakBank.Persistence.Context;

namespace ChumakBank.Persistence.Repositories;

public sealed class KisaCardRepository : BaseRepository<KisaCard>, IKisaCardRepository
{
    public KisaCardRepository(DataContext context) : base(context)
    {
    }
}