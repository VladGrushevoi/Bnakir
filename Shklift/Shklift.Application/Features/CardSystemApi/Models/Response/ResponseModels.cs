using System.Text.Json.Serialization;

namespace ShkliftApplication.Features.CardSystemApi.Models.Response;

public sealed class IsReadyCard
{
    public bool isReady { get; set; }
}

class BaseTransactionConfirmed
{
    
}

sealed class TransactionConfirmedKisa : BaseTransactionConfirmed
{
    public bool isTransactionConfirmed { get; set; }
}

sealed class TransactionConfirmedMapster : BaseTransactionConfirmed
{
    public bool isConfirm { get; set; }
}

public sealed class CardInfo
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("cardNumber")]
    public string CardNumber { get; set; }
    
    [JsonPropertyName("cvv")]
    public string CVV { get; set; }
    
    [JsonPropertyName("expireTo")]
    public string ExpireTo { get; set; }
    
    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; set; }
    
    [JsonPropertyName("countryName")]
    public string CountryName { get; set; }
}