using AutoMapper;
using ChumakBank.Application.Common.CardSystemsCallerApi;
using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using MediatR;

namespace ChumakBank.Application.Features.UserFeatures.CreateCardForUserFeature;

public sealed class CreateCardForUserHandler : IRequestHandler<CreateCardForUserRequest, CreateCardForUserResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly CallerCardSystemApiWrapper _apiWrapper;

    public CreateCardForUserHandler(BaseUnitOfWork unitOfWork, IMapper mapper, SystemCardCallerApi systemCardCallerApi, CallerCardSystemApiWrapper apiWrapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _apiWrapper = apiWrapper;
    }

    public async Task<CreateCardForUserResponse> Handle(CreateCardForUserRequest request, CancellationToken cancellationToken)
    {
        var userData = _mapper.Map<User>(request);

        var userInfo = await _unitOfWork.UserRepository.GetAsync(userData.Id, cancellationToken);

        var userCountry = userInfo.Country;

        var createdCard = await _apiWrapper.CreateCardRequest();
        /*
         * 1. Get User country (+)
         * 2. Send to one of the card systems req for creating card (choosing randomly card system)
         * 3. map response from card system
         * 4. add to db card
         * 5. send response
         */

        return new CreateCardForUserResponse();
    }
}