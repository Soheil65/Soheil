using MyBlazorApp.ViewModels.Requests;
using MyBlazorApp.ViewModels.Responses;
using MyBlazorApp.ViewModels.ViewModels;

namespace MyBlazorApp.ServerConnector.Connectors;

public class UserConnector : BaseConnector, IUserConnector
{
    public UserConnector(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<ApiResponse<UserProfileViewModel>> GetProfileAsync()
    {
        return await GetAsync<UserProfileViewModel>("api/user/profile");
    }

    public async Task<ApiResponse<UserProfileViewModel>> UpdateProfileAsync(UpdateProfileRequest request)
    {
        return await PutAsync<UserProfileViewModel>("api/user/profile", request);
    }
}
