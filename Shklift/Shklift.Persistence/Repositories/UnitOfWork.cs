using Shklift.Persistence.Context;
using ShkliftApplication.Repositories;

namespace Shklift.Persistence.Repositories;

public class UnitOfWork : BaseUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context, ISettingRepository settingRepository, ITransactionRepository transactionRepository)
        : base(transactionRepository, settingRepository)
    {
        _context = context;
    }

    public override async Task SaveAsync(CancellationToken cls)
    {
        await _context.SaveChangesAsync(cls);
    }
}