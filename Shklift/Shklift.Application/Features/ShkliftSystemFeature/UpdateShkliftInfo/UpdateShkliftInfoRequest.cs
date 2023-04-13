using MediatR;

namespace ShkliftApplication.Features.ShkliftSystemFeature.UpdateShkliftInfo;

public sealed record UpdateShkliftInfoRequest(
        Guid Id,
        float Balance,
        float TransactionCommission
    ) : IRequest<UpdateShkliftInfoResponse>;