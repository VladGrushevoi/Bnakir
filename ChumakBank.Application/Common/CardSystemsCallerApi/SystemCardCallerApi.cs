using System.Text.Json;
using ChumakBank.Application.Common.Exception;

namespace ChumakBank.Application.Common.CardSystemsCallerApi;

public sealed class SystemCardCallerApi
{
    private readonly HttpClient _httpClient;

    public SystemCardCallerApi()
    {
        _httpClient = new HttpClient();
    }

    public async Task<TResponse> SendPostMethod<TResponse>(object req, string path, CancellationToken cls) 
        where TResponse : class
    {
        var dataJson = JsonSerializer.Serialize(req);
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