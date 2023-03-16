namespace MapsterCard.AppDbContext.Entities;

public sealed class MapsterMain : BaseEntity
{
    public decimal Balance { get; set; }
    public float PercentageOfOperationsBetweenCountry { get; set; }
    public float PercentageOfOperationsInCountry { get; set; }
}