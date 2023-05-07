namespace KozakBank.Application.Repositories;

public interface IBaseUnitOfWork
{
    public IUserRepository UserRepository { get; set; }
    public IKozakInfoRepository KozakInfoRepository { get; set; }
    public IKisaCardRepository KisaCardRepository { get; set; }
    public IMapsterCardRepository MapsterCardRepository { get; set; }
    public ITransactionHistoryRepository TransactionHistoryRepository { get; set; }

    Task SaveAsync(CancellationToken cls);
}