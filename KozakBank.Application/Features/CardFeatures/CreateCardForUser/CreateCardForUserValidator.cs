using FluentValidation;

namespace KozakBank.Application.Features.CardFeatures.CreateCardForUser;

public sealed class CreateCardForUserValidator : AbstractValidator<CreateCardForUserRequest>
{
    public CreateCardForUserValidator()
    {
        RuleFor(src => src.UserId)
            .NotEmpty().NotNull();
    }
}