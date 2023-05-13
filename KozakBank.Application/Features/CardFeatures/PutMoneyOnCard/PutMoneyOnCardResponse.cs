namespace KozakBank.Application.Features.CardFeatures.PutMoneyOnCard;

public sealed record PutMoneyOnCardResponse
{
    public string Id { get; set; }
    public string CardId { get; set; }
    public string Balance { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}