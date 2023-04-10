using System.Text.Json;
using ShkliftApplication.Common.Exception;
using ShkliftApplication.Features.CardSystemApi.Models.Request;
using ShkliftApplication.Features.CardSystemApi.Models.Response;
using ShkliftApplication.Features.TransactionFeature.CreateTransaction;

namespace ShkliftApplication.Features.CardSystemApi;

public class CardSystemApiCaller : IBaseApi
{
    private readonly HttpClient _httpClient = new();

    public async Task<bool> IsValidCard(CreateTransactionRequest reqData, CancellationToken cls)
    {
        IsReadyCard isFromCardReady;
        IsReadyCard isToCardReady;
        var fromCardNumber = string.Join("", reqData.FromCardNumber.Take(4));
        var toCardNumber = string.Join("", reqData.CardNumberReceiver.Take(4));
        isFromCardReady = fromCardNumber switch
        {
            //4412 is constant 4 first number of kisa card
            "4412" => await SendAsync<IsReadyCard>("http://localhost:5046/card/is-ready-card",
                new
                {
                    CardNumber = reqData.FromCardNumber,
                    CVV = reqData.FromCardCVV,
                    ExpireTo = reqData.FromCardExpire
                }, cls),
            //4411 is constant 4 first number of mapster card
            "4411" => await SendAsync<IsReadyCard>("http://localhost:5229/card/accept-operation",
                new
                {
                    CardNumber = reqData.FromCardNumber,
                    CVV = reqData.FromCardCVV,
                    ExpireTo = reqData.FromCardExpire
                }, cls),
            _ => new IsReadyCard()
        };
        isToCardReady = toCardNumber switch
        {
            //4412 is constant 4 first number of kisa card
            "4412" => await SendAsync<IsReadyCard>("http://localhost:5046/card/is-ready-card",
                new { CardNumber = reqData.CardNumberReceiver }, cls),
            //4411 is constant 4 first number of mapster card
            "4411" => await SendAsync<IsReadyCard>("http://localhost:5229/card/accept-operation",
                new { CardNumber = reqData.CardNumberReceiver }, cls),
            _ => new IsReadyCard()
        };

        return isFromCardReady.isReady && isToCardReady.isReady;
    }

    public async Task<bool> ConfirmTransaction(ConfirmTransactionData reqData, CancellationToken cls)
    {
        string cardSystemNumber = string.Join("", reqData.Card.CardNumber.Take(4));
        BaseTransactionConfirmed confirmed = cardSystemNumber switch
        {
            "4412" => await SendAsync<TransactionConfirmedKisa>("http://localhost:5046/system/confirm-transaction",
                new
                {
                    reqData.Card, reqData.Commission
                }, cls),

            "4411" => await SendAsync<TransactionConfirmedMapster>("http://localhost:5229/system/confirm-transaction",
                new
                {
                    CardInfo = reqData.Card, reqData.Commission
                }, cls),

            _ => throw new BadRequestException($"Card is not available {reqData.Card.CardNumber}")
        };

        if (confirmed is TransactionConfirmedKisa kisa)
        {
            return kisa.isTransactionConfirmed;
        }
        
        return confirmed is TransactionConfirmedMapster { isConfirm: true };
    }

    public Task<object> GetCardInfo(object req)
    {
        throw new NotImplementedException();
    }

    async ValueTask<TResponse> SendAsync<TResponse>(string path, object data, CancellationToken cls)
        where TResponse : class
    {
        var dataJson = JsonSerializer.Serialize(data);
        var request = new HttpRequestMessage(HttpMethod.Post, path);
        var content = new StringContent(dataJson, null, "application/json");
        request.Content = content;
        var response = await _httpClient.SendAsync(request, cls);
        if (!response.EnsureSuccessStatusCode().IsSuccessStatusCode)
        {
            throw new BadRequestException("Request parameters is invalid");
        }

        var resultString = await response.Content.ReadAsStringAsync(cls);
        var result = JsonSerializer.Deserialize<TResponse>(resultString);

        return result;
    }
}