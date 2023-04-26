namespace ChumakBank.Application.Common.CardSystemsCallerApi;

public class CallerCardSystemApiWrapper
{
    private readonly SystemCardCallerApi _systemCardCallerApi;

    public CallerCardSystemApiWrapper(SystemCardCallerApi systemCardCallerApi)
    {
        _systemCardCallerApi = systemCardCallerApi;
    }

    public async Task<CreateCardResponse> CreateCardRequest()
    {
        
        return new CreateCardResponse();
    }
}