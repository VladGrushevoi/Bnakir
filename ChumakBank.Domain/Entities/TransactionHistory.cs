using ChumakBank.Domain.Common;

namespace ChumakBank.Domain.Entities;

public sealed class TransactionHistory : BaseEntity
{
    public Guid FromCardId { get; set; }
    public float AmountMoney { get; set; }
}