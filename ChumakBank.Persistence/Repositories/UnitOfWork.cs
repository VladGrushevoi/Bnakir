using ChumakBank.Application.Repositories;
using ChumakBank.Persistence.Context;

namespace ChumakBank.Persistence.Repositories;

public sealed class UnitOfWork : BaseUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(IUserRepository userRepository, 
        IChumakRepository chumakRepository,
        IKisaCardRepository kisaCardRepository,
        IMapsterCardRepository mapsterCardRepository,
        ITransactionHistoryRepository transactionHistoryRepository,
        DataContext context) : base(userRepository, 
        chumakRepository, 
        mapsterCardRepository, 
        kisaCardRepository,
        transactionHistoryRepository)
    {
        _context = context;
    }

    public override Task SaveAsync(CancellationToken cls)
    {
        _context.DbTransaction.Commit();
        
        return Task.CompletedTask;
    }
}