using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.SystemService.UpdatePercentage;

public sealed class UpdatePercentageHandler : IRequestHandler<UpdatePercentageRequest, UpdatePercentageResponse>
{
    private readonly IMapsterMain _mainRepository;
    private readonly IMapper _mapper;

    public UpdatePercentageHandler(IMapsterMain mainRepository, IMapper mapper)
    {
        _mainRepository = mainRepository;
        _mapper = mapper;
    }

    public async Task<UpdatePercentageResponse> Handle(
        UpdatePercentageRequest request,
        CancellationToken cancellationToken)
    {
        var systemEntity = _mapper.Map<MapsterMain>(request);
        var currSettingEntity = await _mainRepository.GetByIdAsync(systemEntity.Id.Value);

        if (request.PercentageInCountry.HasValue)
            currSettingEntity.PercentageOfOperationsInCountry = systemEntity.PercentageOfOperationsInCountry;

        if (request.PercentageBetweenCountry.HasValue)
            currSettingEntity.PercentageOfOperationsBetweenCountry = systemEntity.PercentageOfOperationsBetweenCountry;

        if (request.PercentageBetweenCardSystem.HasValue)
            currSettingEntity.PercentageOfOperationBetweenCardSystem =
                systemEntity.PercentageOfOperationBetweenCardSystem;

        var result = await _mainRepository.UpdateAsync(currSettingEntity);

        return _mapper.Map<UpdatePercentageResponse>(currSettingEntity);
    }
}