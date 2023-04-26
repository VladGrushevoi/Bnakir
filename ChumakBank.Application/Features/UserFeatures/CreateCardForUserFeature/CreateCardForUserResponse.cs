namespace ChumakBank.Application.Features.UserFeatures.CreateCardForUserFeature;

public sealed record CreateCardForUserResponse
{
    public string Id { get; set; }
    public string CardNumber { get; set; }
}