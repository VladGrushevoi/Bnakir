using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapsterCard.AppDbContext.Repositories;

public sealed class SystemCardRepository : BaseRepository<SystemCard>, ISystemCard
{
    public SystemCardRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<SystemCard>> FindCardsByProperties(SystemCard cardEntity)
    {
        var cards = _context.Cards.AsQueryable();
        if (cardEntity.Id.HasValue)
        {
            cards = cards.Where(c => cardEntity.Id == c.Id);
        }

        if (!string.IsNullOrEmpty(cardEntity.CardNumber) && !string.IsNullOrWhiteSpace(cardEntity.CardNumber))
        {
            cards = cards.Where(c => c.CardNumber == cardEntity.CardNumber);
        }

        if (!string.IsNullOrEmpty(cardEntity.CVV) && !string.IsNullOrWhiteSpace(cardEntity.CVV))
        {
            cards = cards.Where(c => c.CVV == cardEntity.CVV);
        }

        if (!string.IsNullOrEmpty(cardEntity.CountryName) && !string.IsNullOrWhiteSpace(cardEntity.CountryName))
        {
            cards = cards.Where(c => c.CountryName == cardEntity.CountryName);
        }

        if (cardEntity.CreatedAt.HasValue && cardEntity.CreatedAt.Value != default)
        {
            cards = cards.Where(c => c.CreatedAt == cardEntity.CreatedAt);
        }

        if (cardEntity.ExpireTo.HasValue && cardEntity.ExpireTo.Value != default)
        {
            cards = cards.Where(c => c.ExpireTo == cardEntity.ExpireTo);
        }

        return await cards.ToListAsync();
    }
}