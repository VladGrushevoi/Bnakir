namespace ShkliftApplication.Features.CardSystemApi.Models.Request;

public sealed record GetMoneyFromBankRequest
{
    public Guid IdFromCardSystem { get; set; }
    public float AmountMoney { get; set; }
    public string CardNumber { get; set; }
}