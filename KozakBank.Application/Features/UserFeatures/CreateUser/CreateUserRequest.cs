using MediatR;

namespace KozakBank.Application.Features.UserFeatures.CreateUser;

public sealed record CreateUserRequest(
        string Name,
        string Surname,
        string Phone,
        string Country
    ) : IRequest<CreateUserResponse>;