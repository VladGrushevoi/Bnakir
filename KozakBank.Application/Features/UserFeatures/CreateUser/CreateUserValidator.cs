using FluentValidation;

namespace KozakBank.Application.Features.UserFeatures.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(src => src.Name)
            .NotEmpty().NotNull().MinimumLength(3);
        RuleFor(src => src.Surname)
            .NotEmpty().NotNull().MinimumLength(3);
        RuleFor(src => src.Country)
            .NotEmpty().NotNull().MinimumLength(3);
        RuleFor(src => src.Phone)
            .NotEmpty().NotNull().MinimumLength(3);
    }
}