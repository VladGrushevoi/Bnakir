using FluentValidation;

namespace ChumakBank.Application.Features.UserFeatures.DeleteUserFeature;

public sealed class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(src => src.Id)
            .NotNull()
            .NotEmpty();

    }
}