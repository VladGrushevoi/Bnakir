using MediatR;

namespace KozakBank.Application.Features.CardFeatures.CreateCardForUser;

public sealed record CreateCardForUserRequest(
        Guid UserId
    ) : IRequest<CreateCardForUserResponse>;