using ChumakBank.Domain.Common;

namespace ChumakBank.Application.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetAsync(Guid Id, CancellationToken cls);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cls);
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cls);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cls);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cls);
}