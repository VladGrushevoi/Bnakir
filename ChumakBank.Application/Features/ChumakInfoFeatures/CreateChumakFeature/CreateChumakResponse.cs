namespace ChumakBank.Application.Features.ChumakInfoFeatures.CreateChumakFeature;

public sealed record CreateChumakResponse
{
    public string Id { get; set; }
    public string Balance { get; set; }
    public string Commission { get; set; }
    public string BankIdentifier { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}