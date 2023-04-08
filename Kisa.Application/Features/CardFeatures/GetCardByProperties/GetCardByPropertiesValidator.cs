using FluentValidation;

namespace Kisa.Application.Features.CardFeatures.GetCardByProperties;

public class GetCardByPropertiesValidator : AbstractValidator<GetCardByPropertiesRequest>
{
    public GetCardByPropertiesValidator()
    {
        RuleFor(src => src.CardNumber).Length(16);
        RuleFor(src => src.CVV).Length(3);
        RuleFor(src => src.CountryName).MinimumLength(2);
    }
}