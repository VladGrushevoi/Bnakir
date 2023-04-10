using ShkliftApplication.Features.CardSystemApi.Models.Request;
using ShkliftApplication.Features.TransactionFeature.CreateTransaction;

namespace ShkliftApplication.Features.CardSystemApi;

public interface IBaseApi
{
    Task<bool> IsValidCard(CreateTransactionRequest reqData, CancellationToken cls);
    Task<bool> ConfirmTransaction(ConfirmTransactionData reqData, CancellationToken cls);
    Task<object> GetCardInfo(object req);
}