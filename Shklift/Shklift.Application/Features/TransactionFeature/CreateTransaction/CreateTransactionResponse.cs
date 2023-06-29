namespace ShkliftApplication.Features.TransactionFeature.CreateTransaction;

public sealed record CreateTransactionResponse
{
    public string Id { get; set; }
    public string FromCardNumber { get; set; }
    public string ToCardNumber { get; set; }
    public string AmountMoney { get; set; }
    public string DateOfOperation { get; set; }
    public string Commission { get; set; }
    public bool IcConfirmTransaction { get; set; }
}