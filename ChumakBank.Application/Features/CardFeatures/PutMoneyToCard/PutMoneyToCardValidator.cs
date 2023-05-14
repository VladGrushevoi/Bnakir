using FluentValidation;

namespace ChumakBank.Application.Features.CardFeatures.PutMoneyToCard;

public sealed class PutMoneyToCardValidator : AbstractValidator<PutMoneyToCardRequest>
{
    public PutMoneyToCardValidator()
    {
        RuleFor(src => src.SysCardId)
            .NotEmpty().NotNull();
        RuleFor(src => src.Amount)
            .NotEqual(0)
            .GreaterThan(0.01f);
    }
}