using KozakBank.Application.Repositories;

namespace KozakBank.Persistence.Repositories;

public sealed class UnitOfWork : IBaseUnitOfWork
{
    private DataContext.DataContext Context { get; set; }
    public IUserRepository UserRepository { get; set; }
    public IKozakInfoRepository KozakInfoRepository { get; set; }
    public IKisaCardRepository KisaCardRepository { get; set; }
    public IMapsterCardRepository MapsterCardRepository { get; set; }
    public ITransactionHistoryRepository TransactionHistoryRepository { get; set; }
    
    public UnitOfWork(DataContext.DataContext context, IUserRepository userRepository, IKozakInfoRepository kozakInfoRepository, IKisaCardRepository kisaCardRepository, IMapsterCardRepository mapsterCardRepository, ITransactionHistoryRepository transactionHistoryRepository)
    {
        UserRepository = userRepository;
        KozakInfoRepository = kozakInfoRepository;
        KisaCardRepository = kisaCardRepository;
        MapsterCardRepository = mapsterCardRepository;
        TransactionHistoryRepository = transactionHistoryRepository;
        this.Context = context;
    }
    
    public async Task SaveAsync(CancellationToken cls)
    {
        await Context.SaveChangesAsync(cls);
    }
}