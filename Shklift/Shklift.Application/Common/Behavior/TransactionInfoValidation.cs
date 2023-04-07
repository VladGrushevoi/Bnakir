using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using MediatR;
using ShkliftApplication.Common.Exception;
using ShkliftApplication.Features.TransactionFeature.CreateTransaction;

namespace ShkliftApplication.Common.Behavior;

public sealed class TransactionInfoValidation<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is CreateTransactionRequest createTransactionInfo)
        {
            var apiCallResult = new ApiCallCheckCardBuilder(createTransactionInfo);
            await apiCallResult.ExecuteAsync(cancellationToken);
            if (!apiCallResult.Result)
            {
                throw new BadRequestException("Some card does not already to operation");
            }
        }
        return await next();
    }
}

sealed class ApiCallCheckCardBuilder
{
    private readonly CreateTransactionRequest _transReq;
    private readonly HttpClient _httpClient;
    private bool _result = false;
    public bool Result
    {
        get => _result;
    }
    public ApiCallCheckCardBuilder(CreateTransactionRequest reqInfo)
    {
        _transReq = reqInfo;
        _httpClient = new HttpClient();
    }

    public async Task ExecuteAsync(CancellationToken cls)
    {
        bool isFromCardReady = false;
        bool isToCardReady = false;
        var fromCardNumber = string.Join("",_transReq.FromCardNumber.Take(4));
        var toCardNumber = string.Join("",_transReq.CardNumberReceiver.Take(4));
        isFromCardReady = fromCardNumber switch
        {
            //4412 is constant 4 first number of kisa card
            "4412" => await GetIsReadyCardAsync("http://localhost:5046/card/is-ready-card",
                new
                {
                    CardNumber = _transReq.FromCardNumber,
                    CVV = _transReq.FromCardCVV,
                    ExpireTo = _transReq.FromCardExpire
                }, cls),
            //4411 is constant 4 first number of mapster card
            "4411" => await GetIsReadyCardAsync("http://localhost:5229/card/accept-operation",
                new
                {
                    CardNumber = _transReq.FromCardNumber,
                    CVV = _transReq.FromCardCVV,
                    ExpireTo = _transReq.FromCardExpire
                }, cls),
            _ => isFromCardReady
        };
        isToCardReady = toCardNumber switch
        {
            //4412 is constant 4 first number of kisa card
            "4412" => await GetIsReadyCardAsync("http://localhost:5046/card/is-ready-card",
                new { CardNumber = _transReq.CardNumberReceiver }, cls),
            //4411 is constant 4 first number of mapster card
            "4411" => await GetIsReadyCardAsync("http://localhost:5229/card/accept-operation",
                new { CardNumber = _transReq.CardNumberReceiver }, cls),
            _ => isToCardReady
        };

        _result = isFromCardReady && isToCardReady;
    }

    async Task<bool> GetIsReadyCardAsync(string path, object data, CancellationToken cls)
    {
        var dataJson = JsonSerializer.Serialize(data);
        var request = new HttpRequestMessage(HttpMethod.Post, path);
        var content = new StringContent(dataJson, null, "application/json");
        request.Content = content;
        var response = await _httpClient.SendAsync(request, cls);
        response.EnsureSuccessStatusCode();
        var resultString = await response.Content.ReadAsStringAsync(cls);
        var result = JsonSerializer.Deserialize<IsReadyCard>(resultString);

        return result.isReady;
    }
}

record IsReadyCard(bool isReady);