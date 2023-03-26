using Kisa.Domain.Entities;

namespace Kisa.Application.Repositories;

public interface ICardRepository : IBaseRepository<KisaCard>
{
    Task<IEnumerable<KisaCard>> FindCardsByProperties(KisaCard entity, CancellationToken cls);
}