using ShkliftApplication.Features.CardSystemApi.Models.Request;
using ShkliftApplication.Features.CardSystemApi.Models.Response;
using ShkliftApplication.Features.TransactionFeature.CreateTransaction;

namespace ShkliftApplication.Features.CardSystemApi;

public interface IBaseApi
{
    Task<bool> IsValidCard(CreateTransactionRequest reqData, CancellationToken cls);
    Task<bool> ConfirmTransaction(ConfirmTransactionData reqData, CancellationToken cls);
    Task<CardInfo?> GetCardInfo(Card reqData, CancellationToken cls);
    Task<float> GetTransactionCommission(CreateTransactionRequest request, CancellationToken cancellationToken);
    Task<GetMoneyFromBankResponse> GetMoneyFromBank(GetMoneyFromBankRequest reqData, CancellationToken cls);
    Task<SendMoneyToBankResponse> SendMoneyToBank(SendMoneyToBankRequest reqData, CancellationToken cls);
}