using Kisa.Domain.Common;

namespace Kisa.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> CreateAsync(T entity, CancellationToken cls);
    Task<T> UpdateAsync(T entity, CancellationToken cls);
    Task<T> Delete(T entity, CancellationToken cls);
    Task<T> Get(Guid id, CancellationToken cls);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cls);
}