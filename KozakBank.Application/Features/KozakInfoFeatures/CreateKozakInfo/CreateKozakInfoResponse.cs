namespace KozakBank.Application.Features.KozakInfoFeatures.CreateKozakInfo;

public sealed record CreateKozakInfoResponse
{
    public string Id { get; set; }
    public string Balance { get; set; }
    public string CommissionValue { get; set; }
    public string BankIdenrifier { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}