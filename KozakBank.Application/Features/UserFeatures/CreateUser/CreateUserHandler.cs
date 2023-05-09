using AutoMapper;
using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;
using MediatR;

namespace KozakBank.Application.Features.UserFeatures.CreateUser;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseUnitOfWork _unitOfWork;

    public CreateUserHandler(IMapper mapper, IBaseUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<User>(request);

        var result = await _unitOfWork.UserRepository.CreateAsync(userEntity, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<CreateUserResponse>(result);
    }
}