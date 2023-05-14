namespace Kisa.Application.Features.CardFeatures.GetCardByProperties;

public sealed record GetCardByPropertiesResponse
{
    public string Id { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpireTo { get; set; }
    public string CreatedAt { get; set; }
    public string CountryName { get; set; }
}