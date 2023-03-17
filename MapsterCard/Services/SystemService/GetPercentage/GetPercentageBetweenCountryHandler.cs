using AutoMapper;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.SystemService.GetPercentage;

public sealed class GetPercentageBetweenCountryRequest : IRequest<GetPercentageBetweenCountryResponse>{}

public sealed class GetPercentageBetweenCountryResponse
{
    public  string PercentageBetweenCountry { get; set; }
}

public sealed class GetPercentageBetweenCountryHandler : IRequestHandler<GetPercentageBetweenCountryRequest, GetPercentageBetweenCountryResponse>
{
    private readonly IMapsterMain _mainRepository;
    private readonly IMapper _mapper;

    public GetPercentageBetweenCountryHandler(IMapsterMain mainRepository, IMapper mapper)
    {
        _mainRepository = mainRepository;
        _mapper = mapper;
    }

    public async Task<GetPercentageBetweenCountryResponse> Handle(GetPercentageBetweenCountryRequest request, CancellationToken cancellationToken)
    {
        var allRecord = await _mainRepository.GetAllAsync();
        var mainEntity = allRecord.First();

        return _mapper.Map<GetPercentageBetweenCountryResponse>(mainEntity);
    }
}