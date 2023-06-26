using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using Kisa.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kisa.Persistence.Repositories;

public sealed class KisaCardRepository : BaseRepository<KisaCard>, ICardRepository
{
    public KisaCardRepository(DataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<KisaCard>> FindCardsByProperties(KisaCard entity, CancellationToken cls)
    {
        IQueryable<KisaCard> cards = Context.KisaCards;
        if (!string.IsNullOrWhiteSpace(entity.CardNumber))
        {
            cards = cards.Where(x => entity.CardNumber == x.CardNumber);
        }

        if (!string.IsNullOrWhiteSpace(entity.CVV))
        {
            cards = cards.Where(x => entity.CVV == x.CVV);
        }

        if (!string.IsNullOrWhiteSpace(entity.CountryName))
        {
            cards = cards.Where(x => entity.CountryName == x.CountryName);
        }

        if (!string.IsNullOrWhiteSpace(entity.ShortExpireTo))
        {
            cards = cards.Where(x => x.ShortExpireTo == entity.ShortExpireTo);
        }
        if (entity.ExpireTo.HasValue && entity.ExpireTo.Value != default)
        {
            cards = cards.Where(x => entity.ExpireTo == x.ExpireTo);
        }

        if (entity.CreatedAt.HasValue && entity.CreatedAt.Value != default)
        {
            cards = cards.Where(x => entity.CreatedAt == x.CreatedAt);
        }

        return await cards.ToListAsync(cls);
    }
}