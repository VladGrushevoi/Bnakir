namespace ShkliftApplication.Features.CardSystemApi.Models.Request;


public sealed record ConfirmTransactionData
{
    public Card Card { get; set; }
    public float Commission { get; set; }
}

public sealed record Card
{
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ShortExpireTo { get; set; }
}