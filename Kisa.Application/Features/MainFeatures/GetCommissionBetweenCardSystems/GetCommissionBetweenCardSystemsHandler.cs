using AutoMapper;
using Kisa.Application.Repositories;
using MediatR;

namespace Kisa.Application.Features.MainFeatures.GetCommissionBetweenCardSystems;

public sealed class GetCommissionBetweenCardSystemsHandler 
    : IRequestHandler<GetCommissionBetweenCardSystemsRequest, GetCommissionBetweenCardSystemsResponse>
{
    private readonly IMapper _mapper;
    private readonly IKisaMainRepository _kisaMainRepository;

    public GetCommissionBetweenCardSystemsHandler(IMapper mapper, IKisaMainRepository kisaMainRepository)
    {
        _mapper = mapper;
        _kisaMainRepository = kisaMainRepository;
    }

    public async Task<GetCommissionBetweenCardSystemsResponse> Handle(GetCommissionBetweenCardSystemsRequest request, CancellationToken cancellationToken)
    {
        var result = (await _kisaMainRepository.GetAllAsync(cancellationToken)).Last();

        return _mapper.Map<GetCommissionBetweenCardSystemsResponse>(result);
    }
}