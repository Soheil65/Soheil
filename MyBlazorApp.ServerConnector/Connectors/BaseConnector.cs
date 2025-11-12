using System.Net.Http.Json;
using MyBlazorApp.ViewModels.Responses;

namespace MyBlazorApp.ServerConnector.Connectors;

public abstract class BaseConnector
{
    protected readonly HttpClient _httpClient;

    protected BaseConnector(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<T>();
                return ApiResponse<T>.SuccessResponse(data!);
            }
            
            var errorMessage = await response.Content.ReadAsStringAsync();
            return ApiResponse<T>.FailureResponse($"Request failed: {errorMessage}");
        }
        catch (Exception ex)
        {
            return ApiResponse<T>.FailureResponse($"Error: {ex.Message}");
        }
    }

    protected async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, data);
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return ApiResponse<T>.SuccessResponse(result!);
            }
            
            var errorMessage = await response.Content.ReadAsStringAsync();
            return ApiResponse<T>.FailureResponse($"Request failed: {errorMessage}");
        }
        catch (Exception ex)
        {
            return ApiResponse<T>.FailureResponse($"Error: {ex.Message}");
        }
    }

    protected async Task<ApiResponse<T>> PutAsync<T>(string endpoint, object data)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync(endpoint, data);
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return ApiResponse<T>.SuccessResponse(result!);
            }
            
            var errorMessage = await response.Content.ReadAsStringAsync();
            return ApiResponse<T>.FailureResponse($"Request failed: {errorMessage}");
        }
        catch (Exception ex)
        {
            return ApiResponse<T>.FailureResponse($"Error: {ex.Message}");
        }
    }
}
