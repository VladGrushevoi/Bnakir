namespace ShkliftApplication.Features.ShkliftSystemFeature.UpdateShkliftInfo;

public sealed record UpdateShkliftInfoResponse
{
    public string Id { get; set; }
    public string Balance { get; set; }
    public string TransactionCommission { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}