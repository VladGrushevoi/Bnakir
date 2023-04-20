using FluentValidation;

namespace ChumakBank.Application.Features.UserFeatures.CreateUserFeature;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(src => src.Name).NotNull().NotEmpty();
        RuleFor(src => src.Surname).NotNull().NotEmpty();
        RuleFor(src => src.Phone).NotNull().NotEmpty();
        RuleFor(src => src.Country).NotNull().NotEmpty();
    }
}