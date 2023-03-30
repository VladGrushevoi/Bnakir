using MediatR;

namespace Kisa.Application.Features.MainFeatures.GetCommissionInCountry;

public sealed record GetCommissionInCountryRequest : IRequest<GetCommissionInCountryResponse>;