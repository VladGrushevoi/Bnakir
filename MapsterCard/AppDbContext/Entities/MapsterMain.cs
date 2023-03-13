namespace MapsterCard.AppDbContext.Entities;

public sealed class MapsterMain : BaseEntity
{
    public decimal Balance { get; set; }
    public float PercentageOfOperations { get; set; }
}