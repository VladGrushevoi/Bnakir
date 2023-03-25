using Kisa.Application.Repositories;
using Kisa.Persistence.Context;

namespace Kisa.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(CancellationToken cls)
    {
        await _context.SaveChangesAsync(cls);
    }
}