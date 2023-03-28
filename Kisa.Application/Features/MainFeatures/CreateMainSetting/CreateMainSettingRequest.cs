using MediatR;

namespace Kisa.Application.Features.MainFeatures.CreateMainSetting;

public sealed record CreateMainSettingRequest(
        double Balance,
        float CommissionInCountry,
        float CommissionBetweenCountry,
        float CommissionBetweenCardSystem
    ) : IRequest<CreateMainSettingResponse>;