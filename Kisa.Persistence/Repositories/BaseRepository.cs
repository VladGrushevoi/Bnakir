using Kisa.Application.Repositories;
using Kisa.Domain.Common;
using Kisa.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kisa.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DataContext Context;

    public BaseRepository(DataContext context)
    {
        Context = context;
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cls)
    {
        var result = await Context.Set<T>().AddAsync(entity, cls);

        return result.Entity;
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cls)
    {
        return await Task.Run(() =>
        {
            var result = Context.Update(entity);

            return result.Entity;
        }, cls);
    }

    public async Task<T> Delete(T entity, CancellationToken cls)
    {
        return await Task.Run(() =>
        {
            var result = Context.Remove(entity);

            return result.Entity;
        }, cls);
    }

    public async Task<T> Get(Guid id, CancellationToken cls)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id, cls);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cls)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken: cls);
    }
}