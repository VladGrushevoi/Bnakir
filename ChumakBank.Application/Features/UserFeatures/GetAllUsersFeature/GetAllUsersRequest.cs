using MediatR;

namespace ChumakBank.Application.Features.UserFeatures.GetAllUsersFeature;

public sealed record GetAllUsersRequest() : IRequest<GetAllUsersResponse>; 