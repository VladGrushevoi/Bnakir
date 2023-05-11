namespace KozakBank.Application.Features.CardFeatures.CreateCardForUser;

public sealed record CreateCardForUserResponse
{
    public string IdFromSysCard { get; set; }
    public string CardNumber { get; set; }
    public string CreatedAt { get; set; }
}