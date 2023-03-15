using FluentValidation;
using MediatR;

namespace MapsterCard.Services.CardService.AddCard;

public record AddCardRequest(string CountryName) : IRequest<AddCardResponse>;
public record AddCardResponse(
        Guid id,
        string CardNumber,
        string CVV,
        string CountryName,
        DateOnly CreatedAt,
        DateOnly Expire
    );

public class AddCardModelValidator : AbstractValidator<AddCardRequest>
{
    public AddCardModelValidator()
    {
        RuleFor(f => f.CountryName).NotEmpty().NotNull().MinimumLength(3);
    }
}