using AutoMapper;
using Kisa.Application.Repositories;
using Kisa.Domain.Entities;
using MediatR;

namespace Kisa.Application.Features.CardFeatures.GetCardById;

public sealed class GetCardByIdHandler : IRequestHandler<GetCardByIdRequest, GetCardByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;

    public GetCardByIdHandler(IMapper mapper, ICardRepository cardRepository)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
    }

    public async Task<GetCardByIdResponse> Handle(GetCardByIdRequest request, CancellationToken cancellationToken)
    {
        var cardEntity = _mapper.Map<KisaCard>(request);

        var cardResult = await _cardRepository.Get(cardEntity.Id.Value, cancellationToken);

        return _mapper.Map<GetCardByIdResponse>(cardResult);
    }
}