using AutoMapper;
using Kisa.Application.Repositories;
using MediatR;

namespace Kisa.Application.Features.MainFeatures.GetCommissionInCountry;

public class
    GetCommissionInCountryHandler : IRequestHandler<GetCommissionInCountryRequest, GetCommissionInCountryResponse>
{
    private readonly IMapper _mapper;
    private readonly IKisaMainRepository _kisaMainRepository;

    public GetCommissionInCountryHandler(IMapper mapper, IKisaMainRepository kisaMainRepository)
    {
        _mapper = mapper;
        _kisaMainRepository = kisaMainRepository;
    }

    public async Task<GetCommissionInCountryResponse> Handle(GetCommissionInCountryRequest request,
        CancellationToken cancellationToken)
    {
        var result = (await _kisaMainRepository.GetAllAsync(cancellationToken)).Last();

        return _mapper.Map<GetCommissionInCountryResponse>(result);
    }
}