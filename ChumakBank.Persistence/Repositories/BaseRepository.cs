using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Common;

namespace ChumakBank.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public Task<TEntity> GetAsync(Guid Id, CancellationToken cls)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cls)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> CreateAsync(TEntity entity, CancellationToken cls)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cls)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cls)
    {
        throw new NotImplementedException();
    }
}