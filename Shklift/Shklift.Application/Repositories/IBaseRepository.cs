using Shklift.Domain.Common;

namespace ShkliftApplication.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public Task<TEntity?> GetAsync(Guid Id, CancellationToken cls);
    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cls);
    public Task<TEntity> CreateAsync(TEntity entity, CancellationToken cls);
    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cls);
    public Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cls);
}