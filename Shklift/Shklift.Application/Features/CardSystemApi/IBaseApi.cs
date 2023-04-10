using ShkliftApplication.Features.TransactionFeature.CreateTransaction;

namespace ShkliftApplication.Features.CardSystemApi;

public interface IBaseApi
{
    Task<bool> IsValidCard(CreateTransactionRequest reqData, CancellationToken cls);
    Task<bool> ConfirmTransaction(object req);
    Task<object> GetCardInfo(object req);
}