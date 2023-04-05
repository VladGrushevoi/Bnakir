using FluentValidation;
using MediatR;

namespace MapsterCard.Services.CardService.CardReadyToOperation;

public sealed record CardReadyToOperationRequest
    (string CardNumber, string CVV, string Expire) : IRequest<CardReadyToOperationResponse>;

public sealed record CardReadyToOperationResponse
{
    public bool IsReady { get; set; }
}

public sealed class CardReadyToOperationValidation : AbstractValidator<CardReadyToOperationRequest>
{
    public CardReadyToOperationValidation()
    {
        RuleFor(f => f.CardNumber).Length(16);
        RuleFor(f => f.CVV).Length(3);
        RuleFor(f => f.Expire);
    }
}