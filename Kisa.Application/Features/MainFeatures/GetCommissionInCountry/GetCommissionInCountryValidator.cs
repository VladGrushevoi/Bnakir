using FluentValidation;

namespace Kisa.Application.Features.MainFeatures.GetCommissionInCountry;

public sealed class GetCommissionInCountryValidator : AbstractValidator<GetCommissionInCountryRequest>
{
    public GetCommissionInCountryValidator()
    {
    }
}