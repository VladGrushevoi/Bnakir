using FluentValidation;

namespace KozakBank.Application.Features.CardFeatures.GetMoneyFromCard;

public sealed class GetMoneyFromCardValidator : AbstractValidator<GetMoneyFromCardRequest>
{
    public GetMoneyFromCardValidator()
    {
        RuleFor(src => src.SysCardId)
            .NotEmpty().NotNull();
        RuleFor(src => src.AmountMoney)
            .NotNull().NotEmpty().GreaterThan(0.01f);
    }
}