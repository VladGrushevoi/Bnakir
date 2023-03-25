using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using Kisa.Persistence.Context;

namespace Kisa.Persistence.Repositories;

public sealed class MainRepository : BaseRepository<KisaMain>, IKisaMainRepository
{
    public MainRepository(DataContext context) : base(context)
    {
        
    }
}