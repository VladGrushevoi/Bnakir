using MapsterCard.AppDbContext.Entities;

namespace MapsterCard.AppDbContext.Repositories.Interfaces;

public interface ISystemCard : IBaseRepository<SystemCard>
{
    public Task<IEnumerable<SystemCard>> FindCardsByProperties(SystemCard cardEntity);
}