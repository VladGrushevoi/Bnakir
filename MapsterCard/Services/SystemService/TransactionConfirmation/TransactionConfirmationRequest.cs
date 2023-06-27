using FluentValidation;
using MapsterCard.Services.CardService.CardReadyToOperation;
using MediatR;

namespace MapsterCard.Services.SystemService.TransactionConfirmation;

public sealed record TransactionConfirmationRequest(
    CardReadyToOperationRequest cardInfo,
    decimal Commission) : IRequest<TransactionConfirmationResponse>;

public sealed record TransactionConfirmationResponse
{
    public bool IsConfirm { get; set; }
}

class TransactionConfirmationRequestValidation : AbstractValidator<TransactionConfirmationRequest>
{
    public TransactionConfirmationRequestValidation()
    {
        RuleFor(f => f.cardInfo).NotNull();
        RuleFor(f => f.cardInfo.CardNumber)
            .NotNull().NotEmpty().Length(16);
        RuleFor(f => f.cardInfo.CVV)
            .NotNull().NotEmpty().Length(3);
        RuleFor(f => f.cardInfo.ShortExpireTo)
            .NotNull().NotEmpty();
        RuleFor(f => f.Commission).NotNull().GreaterThan(0);
    }
}