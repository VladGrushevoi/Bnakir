using KozakBank.Domain.Common;

namespace KozakBank.Application.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetAsync(Guid id, CancellationToken cls);
    Task<IQueryable<TEntity>> GetAllAsync(CancellationToken cls);
    Task<IEnumerable<TEntity>> GetByProperties(TEntity entity, CancellationToken cls);
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cls);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cls);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cls);
}