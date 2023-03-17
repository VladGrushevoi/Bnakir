using AutoMapper;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.SystemService.GetPercentage;

public sealed class GetPercentageInCountryRequest : IRequest<GetPercentageInCountryResponse>
{
    
} 

public sealed record GetPercentageInCountryResponse
{
    public string PercentageInCountry { get; set; }
}
public sealed class GetPercentageInCountryHandler : IRequestHandler<GetPercentageInCountryRequest, GetPercentageInCountryResponse>
{
    private readonly IMapsterMain _mainRepository;
    private readonly IMapper _mapper;
    public GetPercentageInCountryHandler(IMapsterMain mainRepository, IMapper mapper)
    {
        _mainRepository = mainRepository;
        _mapper = mapper;
    }

    public async Task<GetPercentageInCountryResponse> Handle(GetPercentageInCountryRequest request, CancellationToken cancellationToken)
    {
        var allRecord = await _mainRepository.GetAllAsync();
        var percInCountry = allRecord.First();

        return _mapper.Map<GetPercentageInCountryResponse>(percInCountry);
    }
}