using AutoMapper;
using ChumakBank.Application.Common.CardSystemsCallerApi;
using ChumakBank.Application.Common.Exception;
using ChumakBank.Application.Repositories;
using ChumakBank.Domain.Entities;
using MediatR;

namespace ChumakBank.Application.Features.UserFeatures.CreateCardForUserFeature;

public sealed class CreateCardForUserHandler : IRequestHandler<CreateCardForUserRequest, CreateCardForUserResponse>
{
    private readonly BaseUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly CallerCardSystemApiWrapper _apiWrapper;

    public CreateCardForUserHandler(BaseUnitOfWork unitOfWork, IMapper mapper, SystemCardCallerApi systemCardCallerApi,
        CallerCardSystemApiWrapper apiWrapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _apiWrapper = apiWrapper;
    }

    public async Task<CreateCardForUserResponse> Handle(CreateCardForUserRequest request,
        CancellationToken cancellationToken)
    {
        var userData = _mapper.Map<User>(request);

        var userInfo = await _unitOfWork.UserRepository.GetAsync(userData.Id, cancellationToken);

        var userCountry = userInfo.Country;
        var chumakInfo = await _unitOfWork.ChumakRepository.GetAllAsync(cancellationToken);
        

        var createdCard = await _apiWrapper.CreateCardRequest(new
        {
            CountryName = userCountry, chumakInfo.Last().BankIdentifier
        }, cancellationToken);
        var cardSysCode = string.Join("", createdCard.CardNumber.Take(4));
        object cardEntity = cardSysCode switch
        {
            "4411" => _mapper.Map<MapsterCard>(createdCard),
            "4412" => _mapper.Map<KisaCard>(createdCard),
            _ => throw new InternalException("Cannot identified card system code")
        };
        switch (cardEntity)
        {
            case MapsterCard mpC:
                mpC.UserId = userInfo.Id;
                cardEntity = await _unitOfWork.MapsterCardRepository.CreateAsync(mpC, cancellationToken);
                break;
            case KisaCard kC:
                kC.UserId = userInfo.Id;
                cardEntity = await _unitOfWork.KisaCardRepository.CreateAsync(kC, cancellationToken);
                break;
        }

        await _unitOfWork.SaveAsync(cancellationToken);
        var result = _mapper.Map<CreateCardForUserResponse>(cardEntity);
        result.CardNumber = createdCard.CardNumber;
        /*
         * 1. Get User country (+)
         * 2. Send to one of the card systems req for creating card (choosing randomly card system) (+)
         * 3. map response from card system (+)
         * 4. add to db card(+)
         * 5. send response(+)
         */
        return result;
    }
}