using MediatR;

namespace KozakBank.Application.Features.KozakInfoFeatures.CreateKozakInfo;

public sealed record CreateKozakInfoRequest(
        float Balance,
        float CommissionValue,
        string BankIdentifier
    ) : IRequest<CreateKozakInfoResponse>;