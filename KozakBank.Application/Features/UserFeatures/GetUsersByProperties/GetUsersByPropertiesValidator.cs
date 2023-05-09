using FluentValidation;

namespace KozakBank.Application.Features.UserFeatures.GetUsersByProperties;

public sealed class GetUsersByPropertiesValidator : AbstractValidator<GetUsersByPropertiesRequest>
{
    public GetUsersByPropertiesValidator()
    {
        RuleFor(src => src.FirstName)
            .MinimumLength(3);
        RuleFor(src => src.LastName)
            .MinimumLength(3);
        RuleFor(src => src.PhoneNumber)
            .MinimumLength(3);
        RuleFor(src => src.CountryLiving)
            .MinimumLength(3);
    }
}