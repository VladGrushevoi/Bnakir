using FluentValidation;

namespace Kisa.Application.Features.CardFeatures.CardReadyToOperation;

public sealed class CardReadyToOperationValidator : AbstractValidator<CardReadyToOperationRequest>
{
    public CardReadyToOperationValidator()
    {
        RuleFor(src => src.CardNumber).Length(16).NotNull().NotEmpty();
        RuleFor(src => src.CVV).Length(3).NotNull().NotEmpty();
        RuleFor(src => src.ExpireTo).NotNull().NotEmpty();
    }
}