using AutoMapper;
using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using MediatR;

namespace Kisa.Application.Features.MainFeatures.UpdateMainSetting;

public sealed class UpdateMainSettingHandler : IRequestHandler<UpdateMainSettingRequest, UpdateMainSettingResponse>
{
    private readonly IMapper _mapper;
    private readonly IKisaMainRepository _kisaMainRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMainSettingHandler(IMapper mapper, IKisaMainRepository kisaMainRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _kisaMainRepository = kisaMainRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateMainSettingResponse> Handle(UpdateMainSettingRequest request,
        CancellationToken cancellationToken)
    {
        var entityToUpdate = _mapper.Map<KisaMain>(request);

        var result = await _kisaMainRepository.UpdateAsync(entityToUpdate, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);
        return _mapper.Map<UpdateMainSettingResponse>(result);
    }
}