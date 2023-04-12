using MediatR;

namespace ShkliftApplication.Features.ShkliftSystemFeature.CreateShkliftInfo;

public sealed record CreateShkliftInfoRequest(
        float Balance,
        float CommissionForUsing
    ): IRequest<CreateShkliftInfoResponse>;