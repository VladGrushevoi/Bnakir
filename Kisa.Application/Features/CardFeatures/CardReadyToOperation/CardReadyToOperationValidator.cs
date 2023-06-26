using FluentValidation;

namespace Kisa.Application.Features.CardFeatures.CardReadyToOperation;

public sealed class CardReadyToOperationValidator : AbstractValidator<CardReadyToOperationRequest>
{
    public CardReadyToOperationValidator()
    {
        RuleFor(src => src.CardNumber).Length(16);
        RuleFor(src => src.CVV).Length(3);
        RuleFor(src => src.ExpireToShort).Matches("[0-9]{2}.[0-9]{2}");
    }
}