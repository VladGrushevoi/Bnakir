using AutoMapper;
using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using MediatR;

namespace ChumakBank.Application.Features.UserFeatures.UpdateUserFeature;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserHandler(BaseUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var userNewData = _mapper.Map<User>(request);

        var userFromDb = await _unitOfWork.UserRepository.GetAsync(userNewData.Id, cancellationToken);
        userNewData.CreatedAt = userFromDb.CreatedAt;
        userNewData.UpdatedAt = userFromDb.UpdatedAt;
        
        userFromDb = _mapper.Map<User>(userNewData);

        var result = await _unitOfWork.UserRepository.UpdateAsync(userFromDb, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        return _mapper.Map<UpdateUserResponse>(result);
    }
}