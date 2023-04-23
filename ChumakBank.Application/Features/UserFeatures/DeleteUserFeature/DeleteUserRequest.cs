using MediatR;

namespace ChumakBank.Application.Features.UserFeatures.DeleteUserFeature;

public sealed record DeleteUserRequest(
        Guid Id,
        string Name,
        string Surname,
        string Country,
        string Phone
    ): IRequest<DeleteUserResponse>;