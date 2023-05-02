using FluentValidation;

namespace ChumakBank.Application.Features.CardFeatures.PutMoneyToCard;

public sealed class PutMoneyToCardValidator : AbstractValidator<PutMoneyToCardRequest>
{
    public PutMoneyToCardValidator()
    {
        RuleFor(src => src.CardIdFromSysCard)
            .NotEmpty().NotNull();
        RuleFor(src => src.Amount)
            .NotEqual(0)
            .GreaterThan(0.01f);
    }
}