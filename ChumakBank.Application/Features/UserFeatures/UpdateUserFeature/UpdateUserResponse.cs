namespace ChumakBank.Application.Features.UserFeatures.UpdateUserFeature;

public sealed record UpdateUserResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}