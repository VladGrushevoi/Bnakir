using ChumakBank.Domain.Common;

namespace ChumakBank.Domain.Entities;

public sealed class ChumakInfo : BaseEntity
{
    public float Balance { get; set; }
    public float CommissionForOperation { get; set; }
}