using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.SystemService.AddSystemSettings;

public class AddSystemSettingsHandler : IRequestHandler<AddSystemSettingsRequest, AddSystemSettingsResponse>
{
    private readonly IMapper _mapper;
    private readonly IMapsterMain _mapsterRepository;

    public AddSystemSettingsHandler(IMapper mapper, IMapsterMain mapsterRepository)
    {
        _mapper = mapper;
        _mapsterRepository = mapsterRepository;
    }

    public async Task<AddSystemSettingsResponse> Handle(AddSystemSettingsRequest request, CancellationToken cancellationToken)
    {
        var systemEntity = _mapper.Map<MapsterMain>(request);
        var result = await _mapsterRepository.AddAsync(systemEntity);

        return _mapper.Map<AddSystemSettingsResponse>(result);
    }
}