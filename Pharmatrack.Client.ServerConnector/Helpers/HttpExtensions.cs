using System.Net.Http.Json;
using System.Text.Json;

namespace Pharmatrack.Client.ServerConnector.Helpers;

public static class HttpExtensions
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<T?> GetFromJsonAsync<T>(this HttpClient httpClient, string requestUri)
    {
        return await httpClient.GetFromJsonAsync<T>(requestUri, JsonOptions);
    }

    public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T value)
    {
        return await httpClient.PostAsJsonAsync(requestUri, value, JsonOptions);
    }

    public static async Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T value)
    {
        return await httpClient.PutAsJsonAsync(requestUri, value, JsonOptions);
    }
}
