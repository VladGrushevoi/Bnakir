using MediatR;

namespace Kisa.Application.Features.MainFeatures.GetCommissionBetweenCountry;

public sealed record GetCommissionBetweenCountryRequest : IRequest<GetCommissionBetweenCountryResponse>;