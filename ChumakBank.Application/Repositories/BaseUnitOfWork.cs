namespace ChumakBank.Application.Repositories;

public abstract class BaseUnitOfWork
{
    public readonly IUserRepository UserRepository;
    public readonly IChumakRepository ChumakRepository;

    protected BaseUnitOfWork(IUserRepository userRepository, IChumakRepository chumakRepository)
    {
        UserRepository = userRepository;
        ChumakRepository = chumakRepository;
    }

    public abstract Task SaveAsync(CancellationToken cls);
}