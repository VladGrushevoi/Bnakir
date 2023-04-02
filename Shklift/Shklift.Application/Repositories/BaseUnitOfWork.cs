namespace ShkliftApplication.Repositories;

public abstract class BaseUnitOfWork
{
    public ITransactionRepository _transactionRepository;
    public ISettingRepository _settingRepository;

    protected BaseUnitOfWork(ITransactionRepository transactionRepository, ISettingRepository settingRepository)
    {
        _transactionRepository = transactionRepository;
        _settingRepository = settingRepository;
    }

    public abstract Task SaveAsync(CancellationToken cls);
}