namespace Kisa.Application.Features.CardFeatures.GetCardById;

public sealed record GetCardByIdResponse
{
    public string Id { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string CountryName { get; set; }
    public string ExpireTo { get; set; }
    public string CreatedAt { get; set; }
}