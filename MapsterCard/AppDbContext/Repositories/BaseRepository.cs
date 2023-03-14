using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapsterCard.AppDbContext.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
    
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        var result = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var result = _context.Set<T>().Attach(entity);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<T> RemoveAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        var result = _context.Set<T>().Remove(entity);

        return result.Entity;
    }
}