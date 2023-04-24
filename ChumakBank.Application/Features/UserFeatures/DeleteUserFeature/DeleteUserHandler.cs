using AutoMapper;
using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using MediatR;

namespace ChumakBank.Application.Features.UserFeatures.DeleteUserFeature;

public sealed class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserHandler(BaseUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var userDeleteData = _mapper.Map<User>(request);

        var result = await _unitOfWork.UserRepository.DeleteAsync(userDeleteData, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);
        return _mapper.Map<DeleteUserResponse>(result);
    }
}