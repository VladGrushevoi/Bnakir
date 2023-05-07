using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;

namespace KozakBank.Persistence.Repositories;

public sealed class KozakInfoRepository : BaseRepository<KozakInfo>, IKozakInfoRepository
{
    public KozakInfoRepository(DataContext.DataContext context) : base(context)
    {
    }
}