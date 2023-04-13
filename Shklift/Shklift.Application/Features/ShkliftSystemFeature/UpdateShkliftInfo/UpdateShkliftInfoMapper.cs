using System.Globalization;
using Shklift.Domain.Entities;
using ShkliftApplication.Common;

namespace ShkliftApplication.Features.ShkliftSystemFeature.UpdateShkliftInfo;

public sealed class UpdateShkliftInfoMapper : BaseDto<UpdateShkliftInfoRequest, ShkliftSetting>
{
    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Balance, src => src.Balance)
            .Map(dest => dest.TransactionCommission, src => src.TransactionCommission);
    }
}

public sealed class UpdateShkliftInfoResponseMapper : BaseDto<ShkliftSetting, UpdateShkliftInfoResponse>
{
    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.Id,
                src => src.Id.ToString())
            .Map(dest => dest.Balance,
                src => src.Balance.ToString(CultureInfo.CurrentCulture))
            .Map(dest => dest.TransactionCommission,
                src => src.TransactionCommission.ToString(CultureInfo.CurrentCulture))
            .Map(dest => dest.UpdatedAt,
                src => src.UpdatedAt.ToString())
            .Map(dest => dest.UpdatedAt,
                src => src.UpdatedAt.ToString());

    }
}