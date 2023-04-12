using System.Globalization;
using Shklift.Domain.Entities;
using ShkliftApplication.Common;

namespace ShkliftApplication.Features.ShkliftSystemFeature.CreateShkliftInfo;

public sealed class CreateShkliftInfoMapper : BaseDto<CreateShkliftInfoRequest, ShkliftSetting>
{
    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.CreatedAt, _ => DateOnly.FromDateTime(DateTime.Now))
            .Map(dest => dest.Balance, src => src.Balance)
            .Map(dest => dest.TransactionCommission, src => src.CommissionForUsing);
    }
}

public sealed class CreateShkliftInfoResponseMapper : BaseDto<ShkliftSetting, CreateShkliftInfoResponse>
{
    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.Id, src => src.Id.ToString())
            .Map(dest => dest.Balance,
                src => src.Balance.ToString(CultureInfo.CurrentCulture))
            .Map(dest => dest.CommissionForUsing, 
                src => src.TransactionCommission.ToString(CultureInfo.CurrentCulture));
    }
}