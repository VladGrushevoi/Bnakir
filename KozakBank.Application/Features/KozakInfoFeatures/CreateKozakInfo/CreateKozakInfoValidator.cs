using FluentValidation;

namespace KozakBank.Application.Features.KozakInfoFeatures.CreateKozakInfo;

public sealed class CreateKozakInfoValidator : AbstractValidator<CreateKozakInfoRequest>
{
    public CreateKozakInfoValidator()
    {
        RuleFor(src => src.Balance)
            .NotNull().NotEmpty().GreaterThan(0.01f);
        RuleFor(src => src.BankIdentifier)
            .NotEmpty().NotNull().Length(4);
        RuleFor(src => src.CommissionValue)
            .NotNull().NotEmpty().GreaterThan(0.01f);
    }
}