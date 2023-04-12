using Mapster;
using MediatR;
using Shklift.Domain.Entities;
using ShkliftApplication.Repositories;

namespace ShkliftApplication.Features.ShkliftSystemFeature.CreateShkliftInfo;

public sealed class CreateShkliftInfoHandler : IRequestHandler<CreateShkliftInfoRequest, CreateShkliftInfoResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;

    public CreateShkliftInfoHandler(BaseUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateShkliftInfoResponse> Handle(CreateShkliftInfoRequest request, CancellationToken cancellationToken)
    {
        var shkliftEntity = request.Adapt<ShkliftSetting>();

        var result = await _unitOfWork._settingRepository.CreateAsync(shkliftEntity, cancellationToken);

        return result.Adapt<CreateShkliftInfoResponse>();
    }
}