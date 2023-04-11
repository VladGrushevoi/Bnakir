using System.Text.Json.Serialization;

namespace ShkliftApplication.Features.CardSystemApi.Models.Response;


public record CommissionMapsterBase();
public sealed record CommissionBetweenSystemMapster : CommissionMapsterBase
{
    [JsonPropertyName("percentageBetweenCardSystem")]
    public float CommissionBetweenCardSystems { get; set; }
}

public sealed record CommissionBetweenCountryMapster : CommissionMapsterBase
{
    [JsonPropertyName("percentageBetweenCountry")]
    public float CommissionBetweenCountry { get; set; }
}

public sealed record CommissionInCountryMapster : CommissionMapsterBase
{
    [JsonPropertyName("percentageInCountry")]
    public float CommissionInCountry { get; set; }
}

public record CommissionKisaBase();
public sealed record CommissionBetweenSystemKisa : CommissionKisaBase
{
    [JsonPropertyName("commissionBetweenCardSystems")]
    public float CommissionBetweenCardSystems { get; set; }
}

public sealed record CommissionBetweenCountryKisa : CommissionKisaBase
{
    [JsonPropertyName("commissionBetweenCountry")]
    public float CommissionBetweenCountry { get; set; }
}

public sealed record CommissionInCountryKisa : CommissionKisaBase
{
    [JsonPropertyName("commissionInCountry")]
    public float CommissionInCountry { get; set; }
}