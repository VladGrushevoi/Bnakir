using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChumakBank.Application.Features.UserFeatures.DeleteUserFeature;

public sealed record DeleteUserRequest(
        string Id,
        string Name,
        string Surname,
        string Country,
        string Phone
    ): IRequest<DeleteUserResponse>;