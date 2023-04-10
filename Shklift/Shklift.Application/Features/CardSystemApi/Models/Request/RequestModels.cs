namespace ShkliftApplication.Features.CardSystemApi.Models.Request;


public sealed class ConfirmTransactionData
{
    public Card Card { get; set; }
    public float Commission { get; set; }
}

public sealed class Card
{
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpireTo { get; set; }
}