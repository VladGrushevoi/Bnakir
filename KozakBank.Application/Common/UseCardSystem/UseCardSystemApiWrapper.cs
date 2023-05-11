using KozakBank.Application.Common.UseCardSystem.Models.Request;
using KozakBank.Application.Common.UseCardSystem.Models.Response;

namespace KozakBank.Application.Common.UseCardSystem;

public sealed class UseCardSystemApiWrapper
{
    private readonly UseCardSystemApi _systemCardCallerApi;

    public UseCardSystemApiWrapper(UseCardSystemApi systemCardCallerApi)
    {
        _systemCardCallerApi = systemCardCallerApi;
    }

    public async Task<CreateCardResponse> CreateCardRequest(CreateCardRequest data, CancellationToken cls)
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