using ChumakBank.Application.Common.Exception;

namespace ChumakBank.Application.Common.CardSystemsCallerApi;

public class CallerCardSystemApiWrapper
{
    private readonly SystemCardCallerApi _systemCardCallerApi;

    public CallerCardSystemApiWrapper(SystemCardCallerApi systemCardCallerApi)
    {
        _systemCardCallerApi = systemCardCallerApi;
    }

    public async Task<CreateCardResponse> CreateCardRequest<TRequest>(TRequest data, CancellationToken cls)
    where TRequest : class
    {
        var chooseCardSys = Random.Shared.Next(1, 100);
        var result = chooseCardSys switch
        {
            <= 50 => await _systemCardCallerApi.SendPostMethod<CreateCardResponse>(data,
                "http://localhost:5229/card/add",
                cls),
            > 50 => await _systemCardCallerApi.SendPostMethod<CreateCardResponse>(data,
                "http://localhost:5046/card/create",
                cls)
        };
        return result;
    }
}