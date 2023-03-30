using MediatR;

namespace Kisa.Application.Features.MainFeatures.UpdateMainSetting;

public sealed record UpdateMainSettingRequest(
    string Id,
    double Balance,
    float CommissionInCountry,
    float CommissionBetweenCountry,
    float CommissionBetweenCardSystem
) : IRequest<UpdateMainSettingResponse>;