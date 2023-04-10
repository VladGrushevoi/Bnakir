namespace ShkliftApplication.Features.CardSystemApi.Models.Response;

public sealed class IsReadyCard
{
    public bool isReady { get; set; }
}

class BaseTransactionConfirmed
{
    
}

sealed class TransactionConfirmedKisa : BaseTransactionConfirmed
{
    public bool IsTransactionConfirmed { get; set; }
}

sealed class TransactionConfirmedMapster : BaseTransactionConfirmed
{
    public bool isConfirm { get; set; }
}