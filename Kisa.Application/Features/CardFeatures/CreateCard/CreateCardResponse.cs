namespace Kisa.Application.Features.CardFeatures.CreateCard;

public sealed record CreateCardResponse
{
    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string CreatedAt { get; set; }
    public string ExpireTo { get; set; }
    public string ShortExpireTo { get; set; }
}