namespace ShkliftApplication.Features.ShkliftSystemFeature.CreateShkliftInfo;

public sealed record CreateShkliftInfoResponse
{
    public string Id { get; set; }
    public string Balance { get; set; }
    public string CommissionForUsing { get; set; }
}