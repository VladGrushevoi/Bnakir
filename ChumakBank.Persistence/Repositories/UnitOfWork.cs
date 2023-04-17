using ChumakBank.Application.Repositories;

namespace ChumakBank.Persistence.Repositories;

public sealed class UnitOfWork : BaseUnitOfWork
{
    private readonly IUserRepository _userRepository;
    private readonly IChumakRepository _chumakRepository;

    public UnitOfWork(IUserRepository userRepository, IChumakRepository chumakRepository) : base(userRepository, chumakRepository)
    {
    }

    public override Task SaveAsync(CancellationToken cls)
    {
        throw new NotImplementedException();
    }
}