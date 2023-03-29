namespace Kisa.Application.Features.MainFeatures.ConfirmTransaction;

public sealed record ConfirmTransactionResponse
{
    public bool IsTransactionConfirmed { get; set; }
}