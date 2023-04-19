namespace ChumakBank.Application.Features.UserFeatures;

public sealed record CreateUserResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}