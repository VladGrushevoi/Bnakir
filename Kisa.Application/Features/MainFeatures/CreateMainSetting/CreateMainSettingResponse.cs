namespace Kisa.Application.Features.MainFeatures.CreateMainSetting;

public sealed record CreateMainSettingResponse
{
    public Guid Id { get; set; }
    public string Balance { get; set; }
    public string CommissionInCountry { get; set; }
    public string CommissionBetweenCountry { get; set; }
    public string CommissionBetweenCardSystem { get; set; }
}