using FluentValidation;

namespace Kisa.Application.Features.MainFeatures.ConfirmTransaction;

public sealed class ConfirmTransactionValidator : AbstractValidator<ConfirmTransactionRequest>
{
    public ConfirmTransactionValidator()
    {
        RuleFor(src => src.Card.CardNumber)
            .NotEmpty()
            .NotNull()
            .Length(16);
        RuleFor(src => src.Card.ExpireTo)
            .NotEmpty()
            .NotNull()
            .Must(x => DateOnly.TryParse(x, out _));
        RuleFor(src => src.Card.CVV)
            .NotEmpty()
            .NotNull()
            .Length(3);
        RuleFor(src => src.Commission).GreaterThan(0);
    }
}