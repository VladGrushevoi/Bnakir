using System.Text.Json.Serialization;

namespace KozakBank.Application.Common.UseCardSystem.Models.Response;

public sealed record CreateCardResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("cardNumber")]
    public string CardNumber { get; set; }
    [JsonPropertyName("cvv")]
    public string CVV { get; set; }
    [JsonPropertyName("expireTo")]
    public string ExpireTo { get; set; }
}