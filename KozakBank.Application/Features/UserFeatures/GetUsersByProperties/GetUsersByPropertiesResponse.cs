namespace KozakBank.Application.Features.UserFeatures.GetUsersByProperties;

public sealed record GetUsersByPropertiesResponse
{
    public IEnumerable<object> Data { get; set; }
    public int Count { get; set; }
}