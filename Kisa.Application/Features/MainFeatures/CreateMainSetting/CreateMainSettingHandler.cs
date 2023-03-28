using AutoMapper;
using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using MediatR;

namespace Kisa.Application.Features.MainFeatures.CreateMainSetting;

public sealed class CreateMainSettingHandler : IRequestHandler<CreateMainSettingRequest, CreateMainSettingResponse>
{
    private readonly IMapper _mapper;
    private readonly IKisaMainRepository _kisaMainRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMainSettingHandler(IMapper mapper, IKisaMainRepository kisaMainRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _kisaMainRepository = kisaMainRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateMainSettingResponse> Handle(CreateMainSettingRequest request, CancellationToken cancellationToken)
    {
        var entityToAdd = _mapper.Map<KisaMain>(request);

        var result = await _kisaMainRepository.CreateAsync(entityToAdd, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<CreateMainSettingResponse>(result);
    }
}