namespace ShkliftApplication.Features.CardSystemApi;

public interface IBaseApi<in TRequest, TResponse> 
    where TRequest : class
    where TResponse : class
{
    Task<TResponse> IsValidCard(TRequest req);
    Task<TResponse> ConfirmTransaction(TRequest req);
    Task<TResponse> GetCardInfo(TRequest req);
}