using AutoMapper;
using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using MediatR;

namespace ChumakBank.Application.Features.ChumakInfoFeatures.CreateChumakFeature;

public sealed class CreateChumakHandler : IRequestHandler<CreateChumakRequest, CreateChumakResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateChumakHandler(BaseUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateChumakResponse> Handle(CreateChumakRequest request, CancellationToken cancellationToken)
    {
        var chumakEntity = _mapper.Map<ChumakInfo>(request);

        var result = await _unitOfWork.ChumakRepository.CreateAsync(chumakEntity, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);
        return _mapper.Map<CreateChumakResponse>(result);
    }
}