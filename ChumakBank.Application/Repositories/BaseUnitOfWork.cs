namespace ChumakBank.Application.Repositories;

public abstract class BaseUnitOfWork
{
    public readonly IUserRepository UserRepository;
    public readonly IChumakRepository ChumakRepository;
    public readonly IKisaCardRepository KisaCardRepository;
    public readonly IMapsterCardRepository MapsterCardRepository;
    public readonly ITransactionHistoryRepository TransactionHistoryRepository;

    protected BaseUnitOfWork(IUserRepository userRepository, 
        IChumakRepository chumakRepository, 
        IMapsterCardRepository mapsterCardRepository, 
        IKisaCardRepository kisaCardRepository, 
        ITransactionHistoryRepository transactionHistoryRepository)
    {
        UserRepository = userRepository;
        ChumakRepository = chumakRepository;
        MapsterCardRepository = mapsterCardRepository;
        KisaCardRepository = kisaCardRepository;
        TransactionHistoryRepository = transactionHistoryRepository;
    }

    public abstract Task SaveAsync(CancellationToken cls);
}