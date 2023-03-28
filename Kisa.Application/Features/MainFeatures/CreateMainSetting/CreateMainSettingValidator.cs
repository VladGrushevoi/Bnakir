using FluentValidation;

namespace Kisa.Application.Features.MainFeatures.CreateMainSetting;

public sealed class CreateMainSettingValidator : AbstractValidator<CreateMainSettingRequest>
{
    public CreateMainSettingValidator()
    {
        RuleFor(src => src.Balance)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(src => src.CommissionInCountry)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
        RuleFor(src => src.CommissionBetweenCountry)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
        RuleFor(src => src.CommissionBetweenCardSystem)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}