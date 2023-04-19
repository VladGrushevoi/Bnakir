using ChumakBank.Application.Repositories;
using ChumakBank.Persistence.Context;

namespace ChumakBank.Persistence.Repositories;

public sealed class UnitOfWork : BaseUnitOfWork
{
    public readonly IUserRepository _userRepository;
    public readonly IChumakRepository _chumakRepository;
    private readonly DataContext _context;

    public UnitOfWork(IUserRepository userRepository, IChumakRepository chumakRepository, DataContext context) : base(userRepository, chumakRepository)
    {
        _context = context;
    }

    public override Task SaveAsync(CancellationToken cls)
    {
        _context.DbTransaction.Commit();
        
        return Task.CompletedTask;
    }
}