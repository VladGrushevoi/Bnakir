namespace ChumakBank.Application.Repositories;

public abstract class BaseUnitOfWork
{
    public readonly IUserRepository UserRepository;
    public readonly IChumakRepository ChumakRepository;
    public readonly IKisaCardRepository KisaCardRepository;
    public readonly IMapsterCardRepository MapsterCardRepository;

    protected BaseUnitOfWork(IUserRepository userRepository, IChumakRepository chumakRepository, IMapsterCardRepository mapsterCardRepository, IKisaCardRepository kisaCardRepository)
    {
        UserRepository = userRepository;
        ChumakRepository = chumakRepository;
        MapsterCardRepository = mapsterCardRepository;
        KisaCardRepository = kisaCardRepository;
    }

    public abstract Task SaveAsync(CancellationToken cls);
}