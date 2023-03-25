using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using Kisa.Persistence.Context;

namespace Kisa.Persistence.Repositories;

public sealed class KisaCardRepository : BaseRepository<KisaCard>, ICardRepository
{
    public KisaCardRepository(DataContext context) : base(context)
    {
        
    }
}