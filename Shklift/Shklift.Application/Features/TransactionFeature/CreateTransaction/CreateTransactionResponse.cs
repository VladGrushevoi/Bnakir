namespace ShkliftApplication.Features.TransactionFeature.CreateTransaction;

public sealed record CreateTransactionResponse
{
    public bool IcConfirmTransaction { get; set; }
}