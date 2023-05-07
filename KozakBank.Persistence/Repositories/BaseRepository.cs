using KozakBank.Application.Repositories;
using KozakBank.Domain.Common;

namespace KozakBank.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DataContext.DataContext _context;

    public BaseRepository(DataContext.DataContext context)
    {
        _context = context;
    }

    public Task<TEntity> GetAsync(Guid id, CancellationToken cls)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TEntity>> GetAllAsync(CancellationToken cls)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByProperties(TEntity entity, CancellationToken cls)
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