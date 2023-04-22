using ChumakBank.Domain.Common;

namespace ChumakBank.Application.Features.UserFeatures.GetAllUsersFeature;

public sealed record GetAllUsersResponse
{
    public IEnumerable<object> Data { get; set; }
    public int Total { get; set; }
}