using FluentValidation;

namespace ChumakBank.Application.Features.CardFeatures.GetMoneyFromCard;

public sealed class GetMoneyFromCardValidator : AbstractValidator<GetMoneyFromCardRequest>
{
    public GetMoneyFromCardValidator()
    {
        RuleFor(src => src.IdFromCardSystem)
            .NotEmpty()
            .NotNull();
        RuleFor(src => src.AmountMoney)
            .GreaterThan(0.01f);
    }
}