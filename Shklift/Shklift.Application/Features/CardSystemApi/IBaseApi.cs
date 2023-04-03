namespace ShkliftApplication.Features.CardSystemApi;

public interface IBaseApi<TRequest, TResponse> 
    where TRequest : BaseModelRequest
    where TResponse : BaseModelResponse
{
    Task<TResponse> IsValidCard(TRequest req);
    Task<TResponse> ConfirmTransaction(TRequest req);
    Task<TResponse> GetCardInfo(TRequest req);
}