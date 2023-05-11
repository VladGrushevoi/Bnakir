using AutoMapper;
using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;
using MediatR;

namespace KozakBank.Application.Features.KozakInfoFeatures.CreateKozakInfo;

public sealed class CreateKozakInfoHandler : IRequestHandler<CreateKozakInfoRequest, CreateKozakInfoResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseUnitOfWork _unitOfWork;

    public CreateKozakInfoHandler(IMapper mapper, IBaseUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateKozakInfoResponse> Handle(CreateKozakInfoRequest request, CancellationToken cancellationToken)
    {
        var kozakInfoEntity = _mapper.Map<KozakInfo>(request);

        var result = await _unitOfWork.KozakInfoRepository.CreateAsync(kozakInfoEntity, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);
        return _mapper.Map<CreateKozakInfoResponse>(result);
    }
}