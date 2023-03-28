using FluentValidation;

namespace Kisa.Application.Features.MainFeatures.UpdateMainSetting;

public sealed class UpdateMainSettingValidator : AbstractValidator<UpdateMainSettingRequest>
{
    public UpdateMainSettingValidator()
    {
        RuleFor(src => src.Id)
            .NotEmpty()
            .NotNull()
            .Length(Guid.NewGuid().ToString().Length);
        RuleFor(src => src.Balance)
            .NotEmpty()
            .NotNull()
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