using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;

namespace KozakBank.Persistence.Repositories;

public sealed class KisaCardRepository : BaseRepository<KisaCard>, IKisaCardRepository
{
    public KisaCardRepository(DataContext.DataContext context) : base(context)
    {
    }
}