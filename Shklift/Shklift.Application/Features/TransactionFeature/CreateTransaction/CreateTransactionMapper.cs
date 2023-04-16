using System.Globalization;
using Mapster;
using Shklift.Domain.Entities;
using ShkliftApplication.Common;

namespace ShkliftApplication.Features.TransactionFeature.CreateTransaction;

public sealed class CreateTransactionMapper : BaseDto<CreateTransactionRequest, Transaction>
{
    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.FromCardNumber,
                src => src.FromCardNumber)
            .Map(dest => dest.ToCardNumber,
                src => src.CardNumberReceiver)
            .Map(dest => dest.AmountMoney,
                src => src.AmountMoney.ToString(CultureInfo.CurrentCulture))
            .Map(dest => dest.CreatedAt,
                src => DateOnly.FromDateTime(DateTime.Now));
    }
}

public sealed class CreateTransactionResponseMapper : BaseDto<Transaction, CreateTransactionResponse>
{
    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.IcConfirmTransaction,
                src => src.CreatedAt.HasValue)
            .Map(dest => dest.FromCardNumber,
                src => src.FromCardNumber)
            .Map(dest => dest.ToCardNumber,
                src => src.ToCardNumber)
            .Map(dest => dest.Id,
                src => src.Id.ToString())
            .Map(dest => dest.AmountMoney,
                src => src.AmountMoney)
            .Map(dest => dest.DateOfOperation,
                src => src.CreatedAt.ToString());
    }
}