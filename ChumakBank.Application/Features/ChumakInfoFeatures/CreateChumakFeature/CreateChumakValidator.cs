using FluentValidation;

namespace ChumakBank.Application.Features.ChumakInfoFeatures.CreateChumakFeature;

public sealed class CreateChumakValidator : AbstractValidator<CreateChumakRequest>
{
    public CreateChumakValidator()
    {
        RuleFor(src => src.Balance)
            .NotNull().NotEmpty().GreaterThan(0.01f);
        RuleFor(src => src.CommissionOfOperation)
            .NotEmpty().NotNull().GreaterThan(0.01f);
    }
}