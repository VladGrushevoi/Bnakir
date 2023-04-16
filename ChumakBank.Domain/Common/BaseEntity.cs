namespace ChumakBank.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
}