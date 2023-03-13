using MapsterCard.AppDbContext.Entities;

namespace MapsterCard.AppDbContext.Repositories.Interfaces;

public interface ICrudable<T> where T : BaseEntity
{
    public Task<T?> GetByIdAsync(Guid id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> AddAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<T> RemoveAsync(Guid id);
}