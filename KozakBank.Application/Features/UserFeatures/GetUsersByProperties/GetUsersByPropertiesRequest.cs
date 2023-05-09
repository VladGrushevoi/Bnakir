using MediatR;

namespace KozakBank.Application.Features.UserFeatures.GetUsersByProperties;

public sealed record GetUsersByPropertiesRequest(
        string? FirstName,
        string? LastName,
        string? CountryLiving,
        string? PhoneNumber
    ) : IRequest<GetUsersByPropertiesResponse>;