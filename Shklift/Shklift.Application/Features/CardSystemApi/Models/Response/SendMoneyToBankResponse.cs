using System.Text.Json.Serialization;

namespace ShkliftApplication.Features.CardSystemApi.Models.Response;

public sealed record SendMoneyToBankResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("cardId")]
    public string CardId { get; set; }
    [JsonPropertyName("balance")]
    public string Balance { get; set; }
    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; set; }
    [JsonPropertyName("updatedAt")]
    public string UpdatedAt { get; set; }
}