using AutoMapper;
using Kisa.Application.Repositories;
using MediatR;

namespace Kisa.Application.Features.MainFeatures.GetCommissionBetweenCountry;

public sealed class GetCommissionBetweenCountryHandler
    : IRequestHandler<GetCommissionBetweenCountryRequest, GetCommissionBetweenCountryResponse>
{
    private readonly IMapper _mapper;
    private readonly IKisaMainRepository _kisaMainRepository;

    public GetCommissionBetweenCountryHandler(IMapper mapper, IKisaMainRepository kisaMainRepository)
    {
        _mapper = mapper;
        _kisaMainRepository = kisaMainRepository;
    }

    public async Task<GetCommissionBetweenCountryResponse> Handle(GetCommissionBetweenCountryRequest request,
        CancellationToken cancellationToken)
    {
        var result = (await _kisaMainRepository.GetAllAsync(cancellationToken)).Last();

        return _mapper.Map<GetCommissionBetweenCountryResponse>(result);
    }
}