using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;

namespace KozakBank.Persistence.Repositories;

public sealed class TransactionHistoryRepository : BaseRepository<TransactionHistory>, ITransactionHistoryRepository
{
    public TransactionHistoryRepository(DataContext.DataContext context) : base(context)
    {
    }
}