using Shklift.Domain.Entities;
using Shklift.Persistence.Context;
using ShkliftApplication.Repositories;

namespace Shklift.Persistence.Repositories;

public sealed class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(DataContext context) : base(context)
    {
    }
}