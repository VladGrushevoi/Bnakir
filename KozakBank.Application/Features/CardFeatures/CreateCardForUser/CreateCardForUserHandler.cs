using AutoMapper;
using KozakBank.Application.Common.Exceptions;
using KozakBank.Application.Common.UseCardSystem;
using KozakBank.Application.Common.UseCardSystem.Models.Request;
using KozakBank.Application.Repositories;
using KozakBank.Domain.Entities;
using MediatR;

namespace KozakBank.Application.Features.CardFeatures.CreateCardForUser;

public sealed class CreateCardForUserHandler : IRequestHandler<CreateCardForUserRequest, CreateCardForUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseUnitOfWork _unitOfWork;
    private readonly UseCardSystemApiWrapper _cardSystemApi;

    public CreateCardForUserHandler(IMapper mapper, IBaseUnitOfWork unitOfWork, UseCardSystemApiWrapper cardSystemApi)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _cardSystemApi = cardSystemApi;
    }

    public async Task<CreateCardForUserResponse> Handle(CreateCardForUserRequest request, CancellationToken cancellationToken)
    {
        var userEntity = await _unitOfWork.UserRepository.GetAsync(request.UserId, cancellationToken);
        var bankIdentifier = (await _unitOfWork.KozakInfoRepository.GetAllAsync(cancellationToken))
                                    .OrderBy(x => x.CreatedOnly).Last().BankIdentifier;
        if (userEntity == null) throw new BadRequestException("User not found");

        var createCardRequest = new CreateCardRequest()
        {
            CountryName = userEntity.Country,
            BankIdentifier = bankIdentifier
        };

        var createdCard = await _cardSystemApi.CreateCardRequest(createCardRequest, cancellationToken);
        var cardSysCode = string.Join("", createdCard.CardNumber.Take(4));
        object cardEntity = cardSysCode switch
        {
            "4411" => _mapper.Map<MapsterCard>(createdCard),
            "4412" => _mapper.Map<KisaCard>(createdCard),
            _ => throw new InternalError("Cannot identified card system code")
        };
        switch (cardEntity)
        {
            case MapsterCard mpC:
                mpC.User = userEntity;
                cardEntity = await _unitOfWork.MapsterCardRepository.CreateAsync(mpC, cancellationToken);
                break;
            case KisaCard kC:
                kC.User = userEntity;
                cardEntity = await _unitOfWork.KisaCardRepository.CreateAsync(kC, cancellationToken);
                break;
        }
        
        await _unitOfWork.SaveAsync(cancellationToken);
        var result = _mapper.Map<CreateCardForUserResponse>(cardEntity);
        result.CardNumber = createdCard.CardNumber;

        return result;
    }
}