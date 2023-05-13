using FluentValidation;

namespace KozakBank.Application.Features.CardFeatures.PutMoneyOnCard;

public sealed class PutMoneyOnCardValidator : AbstractValidator<PutMoneyOnCardRequest>
{
    public PutMoneyOnCardValidator()
    {
        RuleFor(src => src.SysCardId)
            .NotNull().NotEmpty();
        RuleFor(src => src.Amount)
            .NotEmpty().NotNull().GreaterThan(0.01f);
    }
}