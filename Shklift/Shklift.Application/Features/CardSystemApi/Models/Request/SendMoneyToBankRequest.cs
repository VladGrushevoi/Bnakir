namespace ShkliftApplication.Features.CardSystemApi.Models.Request;

public sealed record SendMoneyToBankRequest
{
    public Guid SysCardId { get; set; }
    public float Amount { get; set; }

    public string CardNumber { get; set; }
}