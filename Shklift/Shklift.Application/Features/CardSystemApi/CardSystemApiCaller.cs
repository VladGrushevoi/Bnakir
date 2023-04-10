using System.Text.Json;
using ShkliftApplication.Common.Behavior;
using ShkliftApplication.Common.Exception;
using ShkliftApplication.Features.TransactionFeature.CreateTransaction;
using IsReadyCard = ShkliftApplication.Features.CardSystemApi.Models.IsReadyCard;

namespace ShkliftApplication.Features.CardSystemApi;

public class CardSystemApiCaller : IBaseApi
{
    private readonly HttpClient _httpClient = new();
    
    public async Task<bool> IsValidCard(CreateTransactionRequest reqData, CancellationToken cls)
    {
        IsReadyCard isFromCardReady;
        IsReadyCard isToCardReady;
        var fromCardNumber = string.Join("",reqData.FromCardNumber.Take(4));
        var toCardNumber = string.Join("",reqData.CardNumberReceiver.Take(4));
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
            _ => new IsReadyCard(false)
        };
        isToCardReady = toCardNumber switch
        {
            //4412 is constant 4 first number of kisa card
            "4412" => await SendAsync<IsReadyCard>("http://localhost:5046/card/is-ready-card",
                new { CardNumber = reqData.CardNumberReceiver }, cls),
            //4411 is constant 4 first number of mapster card
            "4411" => await SendAsync<IsReadyCard>("http://localhost:5229/card/accept-operation",
                new { CardNumber = reqData.CardNumberReceiver }, cls),
            _ => new IsReadyCard(false)
        };

        return isFromCardReady.isReady && isToCardReady.isReady;
    }

    public Task<bool> ConfirmTransaction(object req)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetCardInfo(object req)
    {
        throw new NotImplementedException();
    }
    
    async ValueTask<TResponse> SendAsync<TResponse>(string path, object data, CancellationToken cls) where TResponse : class
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