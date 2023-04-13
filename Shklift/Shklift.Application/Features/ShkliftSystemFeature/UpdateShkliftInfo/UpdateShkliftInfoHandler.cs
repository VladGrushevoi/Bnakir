using Mapster;
using MediatR;
using Shklift.Domain.Entities;
using ShkliftApplication.Common.Exception;
using ShkliftApplication.Repositories;

namespace ShkliftApplication.Features.ShkliftSystemFeature.UpdateShkliftInfo;

public sealed class UpdateShkliftInfoHandler : IRequestHandler<UpdateShkliftInfoRequest, UpdateShkliftInfoResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;

    public UpdateShkliftInfoHandler(BaseUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateShkliftInfoResponse> Handle(UpdateShkliftInfoRequest request, CancellationToken cancellationToken)
    {
        var shkliftEntity = request.Adapt<ShkliftSetting>();
        var currShklift = await _unitOfWork._settingRepository.GetAsync(shkliftEntity.Id, cancellationToken);
        if (currShklift is null)
        {
            throw new NotFoundException($"Setting not found {request}");
        }
        shkliftEntity.CreatedAt = currShklift?.CreatedAt;
        
        var result = await _unitOfWork._settingRepository.UpdateAsync(shkliftEntity, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);

        return result.Adapt<UpdateShkliftInfoResponse>();
    }
}