using Microsoft.EntityFrameworkCore;
using Shklift.Domain.Common;
using Shklift.Persistence.Context;
using ShkliftApplication.Repositories;

namespace Shklift.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected  DataContext _context { get; }
    
    public BaseRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetAsync(Guid Id, CancellationToken cls)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == Id, cls);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cls)
    {
        return await _context.Set<TEntity>().ToListAsync(cls);
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cls)
    {
        var addedEntity = await _context.Set<TEntity>().AddAsync(entity, cls);

        return addedEntity.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cls)
    {
        return await Task.Run(() =>
        {
            var result = _context.Set<TEntity>().Update(entity);

            return result.Entity;
        }, cls);
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cls)
    {
        return await Task.Run(() =>
        {
            var result = _context.Set<TEntity>().Remove(entity);

            return result.Entity;
        }, cls);
    }
}