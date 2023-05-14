using System.Text.Json.Serialization;

namespace ShkliftApplication.Features.CardSystemApi.Models.Response;

public sealed record GetMoneyFromBankResponse
{
    [JsonPropertyName("money")]
    public float Money { get; set; }
}