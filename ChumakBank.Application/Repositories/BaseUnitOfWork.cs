namespace ChumakBank.Application.Repositories;

public abstract class BaseUnitOfWork
{
    private readonly IUserRepository _userRepository;
    private readonly IChumakRepository _chumakRepository;

    protected BaseUnitOfWork(IUserRepository userRepository, IChumakRepository chumakRepository)
    {
        _userRepository = userRepository;
        _chumakRepository = chumakRepository;
    }

    public abstract Task SaveAsync(CancellationToken cls);
}