namespace ChumakBank.Application.Common.CardSystemsCallerApi;

public sealed record CreateCardResponse
{
    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpireTo { get; set; }
}