using FluentValidation;
using MediatR;

namespace MapsterCard.Services.CardService.AddCard;

public sealed record AddCardRequest(string CountryName) : IRequest<AddCardResponse>;
public sealed record AddCardResponse(
        Guid id,
        string CardNumber,
        string CVV,
        string CountryName,
        DateOnly CreatedAt,
        DateOnly Expire
    );

public sealed class AddCardModelValidator : AbstractValidator<AddCardRequest>
{
    public AddCardModelValidator()
    {
        RuleFor(f => f.CountryName).NotEmpty().NotNull().MinimumLength(3).WithMessage("Country Name have minimum length 3");
    }
}