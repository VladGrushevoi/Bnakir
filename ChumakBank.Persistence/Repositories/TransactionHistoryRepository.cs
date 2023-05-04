using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using ChumakBank.Persistence.Context;

namespace ChumakBank.Persistence.Repositories;

public sealed class TransactionHistoryRepository : BaseRepository<TransactionHistory>, ITransactionHistoryRepository
{
    public TransactionHistoryRepository(DataContext context) : base(context)
    {
    }
}