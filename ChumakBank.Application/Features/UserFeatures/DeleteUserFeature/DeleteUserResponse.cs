namespace ChumakBank.Application.Features.UserFeatures.DeleteUserFeature;

public sealed record DeleteUserResponse
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string DeletedAt { get; set; }
}