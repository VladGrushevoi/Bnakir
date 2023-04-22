using AutoMapper;
using ChumakBank.Application.Repositories;
using MediatR;

namespace ChumakBank.Application.Features.UserFeatures.GetAllUsersFeature;

public sealed class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUsersHandler(BaseUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<GetAllUsersResponse>(users);
    }
}