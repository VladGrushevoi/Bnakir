using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.SystemService.GetPercentage;

public sealed class GetPercentageBetweenCardSystemRequest : IRequest<GetPercentageBetweenCardSystemResponse>
{
}

public sealed class GetPercentageBetweenCardSystemResponse
{
    public float PercentageBetweenCardSystem { get; set; }
}

public class GetPercentageBetweenCardSystem : IRequestHandler<GetPercentageBetweenCardSystemRequest,
    GetPercentageBetweenCardSystemResponse>
{
    private readonly IMapsterMain _mainRepository;
    private readonly IMapper _mapper;

    public GetPercentageBetweenCardSystem(IMapsterMain mainRepository, IMapper mapper)
    {
        _mainRepository = mainRepository;
        _mapper = mapper;
    }

    public async Task<GetPercentageBetweenCardSystemResponse> Handle(GetPercentageBetweenCardSystemRequest request,
        CancellationToken cancellationToken)
    {
        IEnumerable<MapsterMain> allRecods = await _mainRepository.GetAllAsync();
        MapsterMain mainEntity = allRecods.First();

        return _mapper.Map<GetPercentageBetweenCardSystemResponse>(mainEntity);
    }
}