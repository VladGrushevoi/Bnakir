using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MapsterCard.Services.CardService.GetCardById;

public record GetCardByIdRequest([FromQuery] Guid id) : IRequest<GetCardByIdResponse>;
public record GetCardByIdResponse(string CardNumber, string CVV, string CountryName, DateOnly Expire);

public class GetCardByIdValidation : AbstractValidator<GetCardByIdRequest>
{
    public GetCardByIdValidation()
    {
        RuleFor(f => f.id).NotNull().NotEmpty().Must(t => t.GetType() == typeof(Guid));
    }
}