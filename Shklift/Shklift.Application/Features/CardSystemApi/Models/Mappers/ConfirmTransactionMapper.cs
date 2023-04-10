using Mapster;
using ShkliftApplication.Common;
using ShkliftApplication.Features.CardSystemApi.Models.Request;
using ShkliftApplication.Features.TransactionFeature.CreateTransaction;

namespace ShkliftApplication.Features.CardSystemApi.Models.Mappers;

public class ConfirmTransactionMapper : BaseDto<CreateTransactionRequest, ConfirmTransactionData>
{
    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.Card.CardNumber, src => src.FromCardNumber)
            .Map(dest => dest.Card.CVV, src => src.FromCardCVV)
            .Map(dest => dest.Card.ExpireTo, src => src.FromCardExpire)
            .Map(dest => dest.Commission, src => src.Commission);
    }
}