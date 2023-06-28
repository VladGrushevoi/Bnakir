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
        var fromCardNumber = string.Join("", reqData.FromCardNumber.Take(4));
        var toCardNumber = string.Join("", reqData.CardNumberReceiver.Take(4));
        var isFromCardReady = fromCardNumber switch
        {
            //4412 is constant 4 first number of kisa card
            "4412" => await SendAsync<IsReadyCard>("http://localhost:5046/card/is-ready-card",
                new
                {
                    CardNumber = reqData.FromCardNumber,
                    CVV = reqData.FromCardCVV,
                    ExpireTo = reqData.FromCardShortExpire
                }, cls),
            //4411 is constant 4 first number of mapster card
            "4411" => await SendAsync<IsReadyCard>("http://localhost:5229/card/accept-operation",
                new
                {
                    CardNumber = reqData.FromCardNumber,
                    CVV = reqData.FromCardCVV,
                    ExpireTo = reqData.FromCardShortExpire
                }, cls),
            _ => new IsReadyCard()
        };
        var isToCardReady = toCardNumber switch
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

    public async Task<CardInfo?> GetCardInfo(Card reqData, CancellationToken cls)
    {
        string cardSystemNumber = string.Join("", reqData.CardNumber.Take(4));

        CardInfo? cardInfo = cardSystemNumber switch
        {
            "4411" => await SendAsync<CardInfo>("http://localhost:5229/card/search-by-properties", reqData, cls),
            "4412" => await SendAsync<CardInfo>("http://localhost:5046/card/search-card", reqData, cls),
            _ => default
        };

        return cardInfo;
    }

    public async Task<float> GetTransactionCommission(CreateTransactionRequest request, CancellationToken cancellationToken)
    {
        string fromCardSystem = string.Join("", request.FromCardNumber.Take(4));
        string toCardSystem = string.Join("", request.CardNumberReceiver.Take(4));
        if (fromCardSystem != toCardSystem)
        {
            return await GetCommissionBetweenTransactionSystem(fromCardSystem, cancellationToken);
        }

        var fromCardInfo = await GetCardInfo(new Card()
        {
            CardNumber = request.FromCardNumber,
            CVV = request.FromCardCVV,
            ShortExpireTo = request.FromCardShortExpire
        }, cancellationToken);

        var toCardInfo = await GetCardInfo(new Card()
        {
            CardNumber = request.CardNumberReceiver
        }, cancellationToken);

        if (fromCardInfo.CountryName != toCardInfo.CountryName)
        {
            return await GetCommissionBetweenCountry(fromCardSystem, cancellationToken);
        }
        
        return await GetCommissionInCountry(fromCardSystem, cancellationToken);
    }

    private async Task<float> GetCommissionInCountry(string fromCardSystem, CancellationToken cancellationToken)
    {
        CommissionMapsterBase? commissionMapsterValue = fromCardSystem switch
        {
            "4411" => await GetAsync<CommissionInCountryMapster>(
                "http://localhost:5229/system/percentage-in-country", cancellationToken),
            _ => default
        };

        CommissionKisaBase? commissionKisaValue = fromCardSystem switch
        {
            "4412" => await GetAsync<CommissionInCountryKisa>(
                "http://localhost:5046/system/commission-in-country", cancellationToken),
            _ => default
        };
        
        if (commissionMapsterValue is CommissionInCountryMapster inCountryMapster)
        {
            return inCountryMapster.CommissionInCountry;
        }

        return commissionKisaValue is CommissionInCountryKisa inCountryKisa
            ? inCountryKisa.CommissionInCountry
            : -1;
    }

    private async Task<float> GetCommissionBetweenCountry(string fromCardSystem, CancellationToken cancellationToken)
    {
        CommissionMapsterBase? commissionMapsterValue = fromCardSystem switch
        {
            "4411" => await GetAsync<CommissionBetweenCountryMapster>(
                "http://localhost:5229/system/percentage-between-country", cancellationToken),
            _ => default
        };

        CommissionKisaBase? commissionKisaValue = fromCardSystem switch
        {
            "4412" => await GetAsync<CommissionBetweenCountryKisa>(
                "http://localhost:5046/system/commission-between-country", cancellationToken),
            _ => default
        };
        
        if (commissionMapsterValue is CommissionBetweenCountryMapster betweenCountryMapster)
        {
            return betweenCountryMapster.CommissionBetweenCountry;
        }

        return commissionKisaValue is CommissionBetweenCountryKisa betweenCountryKisa
            ? betweenCountryKisa.CommissionBetweenCountry
            : -1;
    }

    private async ValueTask<float> GetCommissionBetweenTransactionSystem(string fromCardSystem, CancellationToken cancellationToken)
    {
        CommissionMapsterBase? commissionMapsterValue = fromCardSystem switch
        {
            "4411" => await GetAsync<CommissionBetweenSystemMapster>(
                "http://localhost:5229/system/percentage-between-card-system", cancellationToken),
            _ => default
        };

        CommissionKisaBase? commissionKisaValue = fromCardSystem switch
        {
            "4412" => await GetAsync<CommissionBetweenSystemKisa>(
                "http://localhost:5046/system/commission-between-card-systems", cancellationToken),
            _ => default
        };

        if (commissionMapsterValue is CommissionBetweenSystemMapster commissionBetweenSystemMapster)
        {
            return commissionBetweenSystemMapster.CommissionBetweenCardSystems;
        }

        return commissionKisaValue is CommissionBetweenSystemKisa betweenSystemKisa
            ? betweenSystemKisa.CommissionBetweenCardSystems
            : -1;
    }

    public async Task<GetMoneyFromBankResponse> GetMoneyFromBank(GetMoneyFromBankRequest reqData, CancellationToken cls)
    {
        var bankIdentifier = string.Join("", reqData.CardNumber.Skip(4).Take(4));
        var result = bankIdentifier switch
        {
            "2023" => await SendAsync<GetMoneyFromBankResponse>("http://localhost:5291/card/get-money",new
            {
                reqData.IdFromCardSystem, reqData.AmountMoney
            }, cls),
            "2320" => await SendAsync<GetMoneyFromBankResponse>("http://localhost:5200/card/get-money", new
            {
                reqData.IdFromCardSystem, reqData.AmountMoney
            }, cls),
            _ => throw new BadRequestException("Bank identifier is invalid")
        };

        return result;
    }

    public async Task<SendMoneyToBankResponse> SendMoneyToBank(SendMoneyToBankRequest reqData, CancellationToken cls)
    {
        var bankIdentifier = string.Join("", reqData.CardNumber.Skip(4).Take(4));
        var result = bankIdentifier switch
        {
            "2023" => await SendAsync<SendMoneyToBankResponse>("http://localhost:5291/card/put-money",new
            {
                reqData.SysCardId, reqData.Amount
            }, cls),
            "2320" => await SendAsync<SendMoneyToBankResponse>("http://localhost:5200/card/put-money", new
            {
                reqData.SysCardId, reqData.Amount
            }, cls),
            _ => throw new BadRequestException("Bank identifier is invalid")
        };

        return result;
    }

    async ValueTask<TResponse> GetAsync<TResponse>(string path, CancellationToken cls) where TResponse : class
    {
        var request = new HttpRequestMessage(HttpMethod.Get, path);
        var response = await _httpClient.SendAsync(request, cls);
        if (!response.IsSuccessStatusCode)
        {
            throw new BadRequestException("Request parameters is invalid");
        }

        var resultString = await response.Content.ReadAsStringAsync(cls);
        var result = JsonSerializer.Deserialize<TResponse>(resultString);

        return result;
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