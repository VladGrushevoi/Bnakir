using FluentValidation;

namespace ChumakBank.Application.Features.UserFeatures.CreateCardForUserFeature;

public sealed class CreateCardForUserValidator : AbstractValidator<CreateCardForUserRequest>
{
    public CreateCardForUserValidator()
    {
        RuleFor(src => src.UserId).NotNull().NotEmpty();
    }
}