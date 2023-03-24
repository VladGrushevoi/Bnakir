using FluentValidation;

namespace Kisa.Application.Features.CardFeatures.CreateCard;

public sealed class CreateCardValidator : AbstractValidator<CreateCardRequest>
{
    public CreateCardValidator()
    {
        RuleFor(src => src.CountryName).NotEmpty().NotNull().MinimumLength(3);
    }
}