using FluentValidation;

namespace ChumakBank.Application.Features.UserFeatures.UpdateUserFeature;

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(src => src.Id).NotEmpty().NotNull();
        RuleFor(src => src.Name).NotEmpty().NotNull();
        RuleFor(src => src.Surname).NotEmpty().NotNull();
        RuleFor(src => src.Phone).NotEmpty().NotNull();
        RuleFor(src => src.Country).NotEmpty().NotNull();
    }
}