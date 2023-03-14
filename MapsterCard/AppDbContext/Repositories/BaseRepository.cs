using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapsterCard.AppDbContext.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _table;
    
    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _table.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _table.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        var result = await _table.AddAsync(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return result.Entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        return await Task.Run(() =>
        {
            var result = _table.Attach(entity);

            return result.Entity;
        });
    }

    public async Task<T> RemoveAsync(Guid id)
    {
        var entity = await _table.FindAsync(id);
        var result = _table.Remove(entity);

        return result.Entity;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}