using MediatR;

namespace ChumakBank.Application.Features.UserFeatures.UpdateUserFeature;

public sealed record UpdateUserRequest(
        Guid Id,
        string Name,
        string Surname,
        string Phone,
        string Country
) : IRequest<UpdateUserResponse>;