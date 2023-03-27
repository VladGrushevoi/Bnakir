using FluentValidation;

namespace Kisa.Application.Features.CardFeatures.GetCardById;

public sealed class GetCardByIdValidator : AbstractValidator<GetCardByIdRequest>
{
    public GetCardByIdValidator()
    {
        RuleFor(src => src.Id).NotNull().NotEmpty();
    }
}