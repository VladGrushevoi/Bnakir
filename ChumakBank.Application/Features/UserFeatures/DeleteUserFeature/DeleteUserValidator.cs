using FluentValidation;

namespace ChumakBank.Application.Features.UserFeatures.DeleteUserFeature;

public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(src => src.Id)
            .NotNull()
            .NotEmpty()
            .Must(x => x != default);
        
    }
}