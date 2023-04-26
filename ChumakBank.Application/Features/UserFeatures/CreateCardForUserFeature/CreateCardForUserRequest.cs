using MediatR;

namespace ChumakBank.Application.Features.UserFeatures.CreateCardForUserFeature;

public sealed record CreateCardForUserRequest(
        string UserId,
        string Name,
        string Surname,
        string Phone
    ) : IRequest<CreateCardForUserResponse>;