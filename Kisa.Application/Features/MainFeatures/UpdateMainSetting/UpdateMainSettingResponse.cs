namespace Kisa.Application.Features.MainFeatures.UpdateMainSetting;

public sealed record UpdateMainSettingResponse
{
    public string Id { get; set; }
    public string Balance { get; set; }
    public string CommissionInCountry { get; set; }
    public string CommissionBetweenCountry { get; set; }
    public string CommissionBetweenCardSystem { get; set; }
}