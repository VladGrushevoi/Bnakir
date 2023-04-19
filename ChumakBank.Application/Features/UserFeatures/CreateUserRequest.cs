using MediatR;

namespace ChumakBank.Application.Features.UserFeatures;

public sealed record CreateUserRequest(
    string Name,
    string Surname,
    string Country,
    string Phone
    ) : IRequest<CreateUserResponse>;