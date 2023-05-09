using AutoMapper;
using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;
using MediatR;

namespace KozakBank.Application.Features.UserFeatures.GetUsersByProperties;

public sealed class GetUsersByPropertiesHandler : IRequestHandler<GetUsersByPropertiesRequest, GetUsersByPropertiesResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseUnitOfWork _unitOfWork;

    public GetUsersByPropertiesHandler(IMapper mapper, IBaseUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetUsersByPropertiesResponse> Handle(GetUsersByPropertiesRequest request, CancellationToken cancellationToken)
    {
        var userEntityForSearching = _mapper.Map<User>(request);

        var result = await _unitOfWork.UserRepository.GetByProperties(userEntityForSearching, cancellationToken);

        return _mapper.Map<GetUsersByPropertiesResponse>(result);
    }
}