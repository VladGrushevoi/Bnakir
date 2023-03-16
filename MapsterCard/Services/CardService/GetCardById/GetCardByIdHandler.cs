using AutoMapper;
using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MediatR;

namespace MapsterCard.Services.CardService.GetCardById;

public class GetCardByIdHandler : IRequestHandler<GetCardByIdRequest, GetCardByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly ISystemCard _cardRepository;

    public GetCardByIdHandler(IMapper mapper, ISystemCard cardRepository)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
    }

    public async Task<GetCardByIdResponse> Handle(GetCardByIdRequest request, CancellationToken cancellationToken)
    {
        var cardEntity = _mapper.Map<SystemCard>(request);
        cardEntity = await _cardRepository.GetByIdAsync(cardEntity.Id.Value);

        return _mapper.Map<GetCardByIdResponse>(cardEntity);
    }
}